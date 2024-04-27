import pygame
import chess

from newPawn import pawn
from newBishop import bishop
from newKnight import knight
from newRook import rook
from newQueen import queen
from newKing import king

class square():
    def __init__ (self, number, length, height, color):
        self.num = number
        self.x = (number)%8 + 1
        self.y = int((number)/8) + 1
        self.index = (self.x, self.y)
        self.length = length
        self.height = height
        self.xpos = self.x * length
        self.ypos = 511 - (self.y * height) + ((600-511)/2)
        if(self.x+self.y) % 2 == 0:
            self.color = 'dark'
        else:
            self.color = 'light'
        if self.color == 'light':
            if color == 0:
                self.drawColor = (255,255,255)
            elif color == 1:
                self.drawColor = (255,183,248)
            elif color == 2:
                self.drawColor = (161,222,255)
            elif color == 3:
                self.drawColor = (255,238,51)
            elif color == 4:
                self.drawColor = (255,175,131)
            elif color == 5:
                self.drawColor = (14,254,255)
        else:
            if color == 0:
                self.drawColor = (30,30,30)
            elif color == 1:
                self.drawColor = (161,0,3)
            elif color == 2:
                self.drawColor = (22,66,0)
            elif color == 3:
                self.drawColor = (119,113,12)
            elif color == 4:
                self.drawColor = (64,44,33)
            elif color == 5:
                self.drawColor = (3,0,89)
        self.pieceOn = None
        self.drawRect = pygame.Rect(self.xpos, self.ypos, self.length, self.height)
        self.pieceOnRect = None
        self.clicked = False
        self.active = False
        

    def setPiece(self, nickname):
        if(nickname == chess.Piece.from_symbol('p')):
            self.pieceOn = pawn('black', self)
        elif(nickname == chess.Piece.from_symbol('b')):
            self.pieceOn = bishop('black', self)
        elif(nickname == chess.Piece.from_symbol('n')):
            self.pieceOn = knight('black', self)
        elif(nickname == chess.Piece.from_symbol('r')):
            self.pieceOn = rook('black', self) 
        elif(nickname == chess.Piece.from_symbol('k')):
            self.pieceOn = king('black', self)
        elif(nickname == chess.Piece.from_symbol('q')):
            self.pieceOn = queen('black', self)
        elif(nickname == chess.Piece.from_symbol('P')):
            self.pieceOn = pawn('white', self)
        elif(nickname == chess.Piece.from_symbol('B')):
            self.pieceOn = bishop('white', self)
        elif(nickname == chess.Piece.from_symbol('N')):
            self.pieceOn = knight('white', self)
        elif(nickname == chess.Piece.from_symbol('R')):
            self.pieceOn = rook('white', self)
        elif(nickname == chess.Piece.from_symbol('K')):
            self.pieceOn = king('white', self)
        elif(nickname == chess.Piece.from_symbol('Q')):
            self.pieceOn = queen('white', self)
        else:
            self.pieceOn = None
        


    def getActualX(self, i):
        return ((800-511)/2) + (511-((i%8)*self.length)-self.length)
    def getActualY(self,i):
        return ((600-511)/2) + (511 - (int(i/8)*self.height) - self.height)
    
    def getUCI(self, turn):
        if turn == 'white':
            xindex = 'abcdefgh'
            x = str(xindex[(self.x - 1)])
            y = str(self.y)
        else:
            xindex = 'hgfedcba'
            x = str(xindex[(self.x - 1)])
            y = str((9 - self.y))    
        uci = x + y
        return uci
        
    
    def drawSquare(self, window, active):
        if active != None:
            if active.__contains__(self.num):
                self.drawColor = 'green'
        pygame.draw.rect(window, self.drawColor, self.drawRect)
            
        if self.pieceOn != None and self.active == False:
            self.pieceOn.drawPiece(window)
        
        