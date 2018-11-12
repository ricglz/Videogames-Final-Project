using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour {

	public Texture2D image;
	public int blocksPerLine;
	public int shuffleLength = 40;
	Block emptyBlock;
	Block[,] blocks;
	Queue<Block> inputs;
	bool blockIsMoving;
	int shuffleMovesRemaining;
	Vector2Int previousShuffleOffset;
	float playerMoveDuration = .2f;
	float shuffleMoveDuration = .05f;
	enum GameState { Solved, Shuffling, Playing }
	GameState state;

	void Start(){
		CreatePuzzle();
		StartShuffle();
	}

	void CreatePuzzle() {
		blocksPerLine = PuzzleManager.currentPiecesPerLine;
		blocks = new Block[blocksPerLine, blocksPerLine];
		Texture2D[,] imageSlices = ImageSlicer.GetSlices(image, blocksPerLine);
		playerMoveDuration = .2f / PuzzleManager.difficulty;
		for(int i = 0; i < blocksPerLine; i++) {
			for(int j = 0; j < blocksPerLine; j++) {
				GameObject blockObject = GameObject.CreatePrimitive(PrimitiveType.Quad);
				blockObject.transform.position = -Vector2.one * (blocksPerLine - 1) * .5f + new Vector2(j, i);
				blockObject.transform.parent = transform;

				Block block = blockObject.AddComponent<Block>();
				block.OnBlockPressed += PlayerMoveBlockInput;
				block.OnFinishedMoving += OnBlockFinishedMoving;
				block.init(new Vector2Int(j, i), imageSlices[j, i]);
				blocks[j, i] = block;

				if(i == 0 && j == blocksPerLine - 1) {
					emptyBlock = block;
				}
			}
		}
		Camera.main.orthographicSize = blocksPerLine * .55f;
		inputs = new Queue<Block>();
	}

	void PlayerMoveBlockInput(Block blockToMove) {
		if(state == GameState.Playing) {
			inputs.Enqueue(blockToMove);
			MakeNextPlayerMove();
		}
	}

	void MakeNextPlayerMove() {
		while(inputs.Count > 0 && !blockIsMoving) {
			MoveBlock(inputs.Dequeue(), playerMoveDuration);
		}
	}

	void MoveBlock(Block blockToMove, float duration) {
		if(nextToEmptyBlock(blockToMove)) {
			blocks[blockToMove.coord.x, blockToMove.coord.y] = emptyBlock;
			blocks[emptyBlock.coord.x, emptyBlock.coord.y] = blockToMove;

			Vector2Int targetCoord = blockToMove.coord;
			blockToMove.coord = emptyBlock.coord;
			emptyBlock.coord = targetCoord;

			Vector2 targetPos = emptyBlock.transform.position;
			emptyBlock.transform.position = blockToMove.transform.position;
			blockToMove.MoveToPosition(targetPos, duration);
			blockIsMoving = true;
		}
	}

	bool nextToEmptyBlock(Block blockToMove) {
		return (blockToMove.coord - emptyBlock.coord).sqrMagnitude == 1;
	}

	void OnBlockFinishedMoving() {
		blockIsMoving = false;
		CheckIfIsSolved();
		if(state == GameState.Playing) {
			MakeNextPlayerMove();
		} else if(state == GameState.Shuffling) {
			if(shuffleMovesRemaining > 0) {
				makeNextShuffleMove();
			} else {
				state = GameState.Playing;
			}
		}
	}

	void StartShuffle() {
		state = GameState.Shuffling;
		shuffleMovesRemaining = shuffleLength;
		emptyBlock.gameObject.SetActive(false);
		makeNextShuffleMove();
	}

	void makeNextShuffleMove() {
		Vector2Int[] offsets = {new Vector2Int(1, 0), new Vector2Int(-1, 0), 
							  new Vector2Int(0, 1), new Vector2Int(0, -1)};
		int randomIndex = Random.Range(0, offsets.Length);

		for(int i = 0; i < offsets.Length; i++) {
			Vector2Int offset = offsets[(randomIndex + i) % offsets.Length];
			if(offset != previousShuffleOffset*-1) {
				Vector2Int moveBlockCoord = emptyBlock.coord + offset;
				if(validMove(moveBlockCoord)) {
					MoveBlock(blocks[moveBlockCoord.x, moveBlockCoord.y], shuffleMoveDuration);
					shuffleMovesRemaining--;
					previousShuffleOffset = offset;
					break;
				}
			}
		}
	}

	bool validMove(Vector2Int coord) {
		return inBounds(coord.x) && inBounds(coord.y);
	}

	bool inBounds(int axis) {
		return axis >= 0 && axis < blocksPerLine;
	}

	void CheckIfIsSolved() {
		if(state != GameState.Playing) {
			return;
		}
		foreach(Block block in blocks) {
			if(!block.isAtStartingCoordinate()) {
				return;
			}
		}
		state = GameState.Solved;
		RestartGame();
	}

	void RestartGame() {
		PuzzleManager.GameWon();
		clearPuzzle();
		CreatePuzzle();
		StartShuffle();
	}

	void clearPuzzle() {
		int childs = transform.childCount;
		for (int i = childs - 1; i >= 0; i--) {
			GameObject.Destroy(transform.GetChild(i).gameObject);
		}
	}
}
