import chess
import pygame


class pawn():
    def __init__(self, color, square):
        self.color = color
        if self.color == 'black':
            self.img = pygame.image.load("black-pawn.png")
            self.nickname = 'p'
        else:
            self.img = pygame.image.load("white-pawn.png")
            
            self.nickname = 'P'
        self.onSquare = square
        self.isActive = False
        self.isCaptured = False
        self.rect = self.img.get_rect()
        if self.onSquare != None:
            self.img = pygame.transform.scale(self.img, (self.onSquare.length, self.onSquare.height))
            self.rect.topleft = (self.onSquare.xpos, self.onSquare.ypos)

        self.draw = True
    def setSquare(self, squareGrid, x):
        self.onSquare = squareGrid[x]
    def isClicked(self, window, x, y):
        window.blit(self.img, (x,y))
    def drawPiece(self, window):
        if(self.isActive == False) and (self.isCaptured == False):
            window.blit(self.img, self.rect)


    
        
