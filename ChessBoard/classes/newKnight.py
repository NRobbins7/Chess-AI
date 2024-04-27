import chess
import pygame


class knight():
    def __init__(self, color, square):
        self.color = color
        if self.color == 'black':
            self.img = pygame.image.load("ChessBoard/black-knight.png")
            self.nickname = 'n'
        else:
            self.img = pygame.image.load("ChessBoard/white-knight.png")
            self.nickname = 'N'
        self.onSquare = square
        self.isActive = False
        self.rect = self.img.get_rect()
        if self.onSquare != None:
            self.img = pygame.transform.scale(self.img, (self.onSquare.length, self.onSquare.height))
            self.rect.topleft = (self.onSquare.xpos, self.onSquare.ypos)
        self.isCaptured = False
        self.draw = True
    def setSquare(self, squareGrid, x):
        self.onSquare = squareGrid[x]
    def drawPiece(self, window):
        if(self.isActive == False) and (self.isCaptured == False):
            window.blit(self.img, self.rect)