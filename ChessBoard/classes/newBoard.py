import pygame
import chess
from square import square
from menu import menu

class board():
    def __init__(self):
        self.width = 511
        self.height = 511
        self.squareWidth = self.width/8
        self.squareHeight = self.height/8
        self.turn = 'white'
        self.boardPos = chess.Board()
        self.moveCount = 0
        self.lastMove = None
        self.gameIsOver = False
        self.menu = menu()
        self.flipped = False
        self.color = 0
        self.grid = self.squareGrid()
    
    def makeMove(self, move, window, ai):
        if self.boardPos.legal_moves.__contains__(chess.Move.from_uci(move)):
            self.boardPos.push_uci(move)
            if(self.boardPos.is_checkmate() == True) or (self.boardPos.is_stalemate() == True) or (self.boardPos.can_claim_draw() == True):
                self.gameIsOver = True
                print(True)
                self.getEnding(window)
            else:
                self.changeTurn(ai)
            

    def squareGrid(self):
        grid = []
        for i in range(64):
            newSquare = square(i,self.width/8,self.height/8, self.color)
            grid.append(newSquare)
        return grid
    def drawBoard(self):
        self.grid = self.squareGrid()
        for i in range(64):
            if self.boardPos.piece_at(i) != None:
                if self.flipped == True:
                    self.grid[63 - i].setPiece(self.boardPos.piece_at(i))
                else:
                    self.grid[i].setPiece(self.boardPos.piece_at(i))
                
    def drawBoardWindow(self, window, active):
        for i in range(len(self.grid)):
            self.grid[i].drawSquare(window, active)
            
    def getSquareClicked(self, x, y):
        xsquare = int((x-(800 - self.width)/2)/self.squareWidth)
        ysquare = 7 - int((y-(600 - self.width)/2)/self.squareHeight)
        return xsquare + (ysquare*8)
    
    def getEnding(self, window):
        if self.boardPos.is_checkmate() == True:
            if self.turn == 'white':
                self.menu.gameEndWhite(window)
            if self.turn == 'black':
                self.menu.gameEndBlack(window)
        else:
            self.menu.gameEndDraw(window)


    def changeTurn(self, ai):
        if self.turn == 'white':
            self.turn = 'black'
            if ai == False:
                self.flipped = True
            
        else:
            self.turn = 'white'
            if ai == False:
                self.flipped = False
            
    
    
    def newGame(self):
        self.boardPos = chess.Board()
        self.turn = 'white'
        self.grid = self.squareGrid()
        self.gameIsOver = False
        self.flipped = False
    
    def setColor(self, color):
        self.color = color

    def getLegalSquares(self, num, flipped):
        legalsquares = []
        possibleMoves = list(self.boardPos.legal_moves)
        for i in range(len(possibleMoves)):
            if flipped == False:
                if num == possibleMoves[i].from_square:
                    legalsquares.append(possibleMoves[i].to_square)
            else:
                if 63 - num == possibleMoves[i].from_square:
                    legalsquares.append(63 - possibleMoves[i].to_square)
        return legalsquares
