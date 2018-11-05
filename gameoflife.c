#include <stdio.h>
#include <stdlib.h>
#include <string.h>

void getFirstLine();
void createGrid();
void gameOfLife();
int getNeighbours();
int checkNeighbour();

/* 103599 Accepted */

int main()
{
    int numRows, numColumns, numSteps, i, i2 = 0;
    //char tempChar;
    getFirstLine(&numRows, &numColumns, &numSteps);
    getchar();
    //create game array
    char **gameGrid;
    gameGrid =(char **) malloc(numRows*sizeof(char *));
    for (i = 0; i<numRows; i++){
        gameGrid[i] = (char *) malloc(numColumns*sizeof(char));
    }
    //populate gameGrid
    createGrid(gameGrid, numRows, numColumns);
    //do the game
    gameOfLife(gameGrid, numRows, numColumns, numSteps);
    //finally, print the grid
    for (i=0; i<numRows; i++){
        for (i2=0; i2<numColumns; i2++){
            printf("%c", gameGrid[i][i2]);
        }
        //print new line to make it look griddy
        printf("\n");
    }
    free(gameGrid);
}

void getFirstLine(int *rows, int *cols, int *steps){
    int tempNum;
    scanf("%d", &tempNum);
    *rows = tempNum;
    scanf("%d", &tempNum);
    *cols = tempNum;
    scanf("%d", &tempNum);
    *steps = tempNum;
}

void createGrid(char **grid, int rows, int cols){
    int i, i2;
    char tempChar;
    char *currentString = (char*)malloc(cols+1 * sizeof(char));
    for (i=0; i<rows; i++){
        fgets(currentString, cols+1, stdin);
        for (i2=0; i2<cols; i2++){
            tempChar = currentString[i2];
            grid[i][i2] = tempChar;
        }
        //get rid of \n in buffer
        getchar();
    }
    free(currentString);
}

void gameOfLife(char **firstGrid, int numOfRow, int numOfCol, int steps){
    int row, col, neighbours, i;
    //make a second grid
    char** secondGrid =(char **) malloc(numOfRow*sizeof(char *));
    for (i = 0; i<numOfRow; i++){
        secondGrid[i] = (char *) malloc(numOfCol*sizeof(char));
    }
    //initial set of secondGrid to firstGrid
    for (row=0; row<numOfRow; row++){
        for (col=0; col<numOfCol; col++){
            //tempChar = firstGrid[row][col];
            secondGrid[row][col] = firstGrid[row][col];
        }
    }
    //for each ROW in the array
    for (i = 0; i<steps; i++){
        for (row = 0; row<numOfRow; row++){
            //for each column in that row
            for (col = 0; col<numOfCol; col++){
                //check the amount of LIVING neighbouring cells
                neighbours = getNeighbours(firstGrid, row, col, numOfRow, numOfCol);
                //now decide what to do with the result of neighbour
                //check for death first because we're optimists
                if (neighbours < 2 || neighbours > 3){
                    //tempChar = '.';
                    secondGrid[row][col] = '.';
                } else if (neighbours == 2 && firstGrid[row][col] == 'X'){
                    //check to see if there are 2 neighbours and the cell is alive
                    //if so, keep it that way
                    secondGrid[row][col] = 'X';
                } else if (neighbours == 3){
                    //left with 3 neighbours so will be alive
                    secondGrid[row][col] = 'X';
                } else {
                    secondGrid[row][col] = '.';
                }
            }
        }
        //copy second array to first array
        for (row=0; row<numOfRow; row++){
            for (col=0; col<numOfCol; col++){
                firstGrid[row][col] = secondGrid[row][col];
            }
        }
    }
    free(secondGrid);
}

int getNeighbours(char **grid, int row, int col, int maxRow, int maxCol){
    int result = 0;
    //check all around the cell
    //   1 2 3 R
    // 1 . . .
    // 2 . x .
    // 3 . . .
    // C

    //(R,C), initial input would be (2,2)

    //(1,1)
    result += checkNeighbour(grid, row-1, col-1, maxRow, maxCol);
    //(1,2)
    result += checkNeighbour(grid, row-1, col, maxRow, maxCol);
    //(1,3)
    result += checkNeighbour(grid, row-1, col+1, maxRow, maxCol);
    //(2,1)
    result += checkNeighbour(grid, row, col-1, maxRow, maxCol);
    //(2,2) don't check itself
    //(2,3)
    result += checkNeighbour(grid, row, col+1, maxRow, maxCol);
    //(3,1)
    result += checkNeighbour(grid, row+1, col-1, maxRow, maxCol);
    //(3,2)
    result += checkNeighbour(grid, row+1, col, maxRow, maxCol);
    //(3,3)
    result += checkNeighbour(grid, row+1, col+1, maxRow, maxCol);

    //return the result
    return result;
}

int checkNeighbour(char **grid, int row, int col, int maxRow, int maxCol){
    //make sure where being checked is not out of bounds
    if (row < 0 || row >= maxRow || col < 0 || col >=maxCol){
        //out of bounds, return 0
        return 0;
    } else {
        //in bounds, so check if is alive (x) or dead (.)
        if (grid[row][col] == 'X'){
            //IT'S ALIVE!
            return 1;
        } else {
            //dead
            return 0;
        }
    }
}
