import pygame
from button import button

class menu():
    def __init__(self):
        self.backgroundImg = pygame.transform.scale(pygame.image.load("background.png"), (800,600))
        self.backgroundDraw = button(0, 0, self.backgroundImg)
        #main menu buttons
        self.startGameButtonImg = pygame.image.load("startLocal.png")
        self.startGameButtonImg = pygame.transform.scale_by(self.startGameButtonImg, 1)
        self.startGameButton = button((800 - self.startGameButtonImg.get_rect().width)/2, 200, self.startGameButtonImg)

        self.startAIButtonImg = pygame.image.load("startAI.png")
        self.startAIButton = button((800 - self.startAIButtonImg.get_rect().width)/2, 325, self.startAIButtonImg)

        self.isClicked = False
        self.colorMenuOpenImg = pygame.image.load("openMenuButton.png")
        self.colorMenuOpenButton = button(750, 20, self.colorMenuOpenImg)

        self.colorMenuImg = pygame.transform.scale(pygame.image.load("colorMenu.png"), (200,250))
        self.colorMenuButton = button(580, 50, self.colorMenuImg)

        self.whiteblackImg = pygame.image.load("white.png")
        self.whiteblackButton = button(700, 70, self.whiteblackImg)
        self.redpinkImg = pygame.image.load("pink.png")
        self.redpinkButton = button(740, 70, self.redpinkImg)
        self.orangeyellowImg = pygame.image.load("yellow.png")
        self.orangeyellowButton = button(700, 110, self.orangeyellowImg)
        self.greenblueImg = pygame.image.load("blue.png")
        self.greenblueButton = button(740, 110, self.greenblueImg)
        self.brownbeigeImg = pygame.image.load("brown.png")
        self.brownbeigeButton = button(700, 150, self.brownbeigeImg)
        self.navyturquoiseImg = pygame.image.load("navy.png")
        self.navyturquoiseButton = button(740, 150, self.navyturquoiseImg)
        #game end menu buttons
        self.rematchImg = pygame.image.load("rematch.png")
        self.rematchButton = button((800 - self.rematchImg.get_rect().width)/2, 270, self.rematchImg)

        self.toMenuImg = pygame.image.load("toMenu.png")
        self.toMenuButton = button((800 - self.toMenuImg.get_rect().width)/2, 350, self.toMenuImg)

        #AI color select menu buttons
        self.colorSelectMenuImg = pygame.transform.scale(pygame.image.load("chooseColorMenu.png"), (400, 350))
        self.colorSelectMenu = button(200, 125, self.colorSelectMenuImg)

        self.chooseWhiteImg = pygame.transform.scale(pygame.image.load("chooseWhite.png"), (100,100))
        self.chooseWhiteButton = button(255, 340, self.chooseWhiteImg)
        self.chooseBlackImg = pygame.transform.scale(pygame.image.load("chooseBlack.png"), (100,100))
        self.chooseBlackButton = button(450, 340, self.chooseBlackImg)
    def draw_menu(self, window):
        self.startGameButton.draw(window)
        self.startAIButton.draw(window)
        self.colorMenuOpenButton.draw(window)
        if self.isClicked == True:
            self.whiteblackButton.draw(window)
            self.redpinkButton.draw(window)
            self.orangeyellowButton.draw(window)
            self.greenblueButton.draw(window)
            self.brownbeigeButton.draw(window)
            self.navyturquoiseButton.draw(window)

    def gameEndWhite(self, window):
        gameEndImg = pygame.transform.scale(pygame.image.load("gameEndWhite.png"), (300, 350))
        gameEnd = button(250, 125, gameEndImg)
        gameEnd.draw(window)
        self.rematchButton.draw(window)
        self.toMenuButton.draw(window)
    def gameEndBlack(self, window):
        gameEndImg = pygame.transform.scale(pygame.image.load("gameEndWhite.png"), (300, 350))
        gameEnd = button(250, 125, gameEndImg)
        gameEnd.draw(window)
        self.rematchButton.draw(window)
        self.toMenuButton.draw(window)
    def gameEndDraw(self, window):
        gameEndImg = pygame.transform.scale(pygame.image.load("gameEndWhite.png"), (300, 350))
        gameEnd = button(250, 125, gameEndImg)
        gameEnd.draw(window)
        self.rematchButton.draw(window)
        self.toMenuButton.draw(window)

    def chooseColor(self, window):
        self.colorSelectMenu.draw(window)
        self.chooseBlackButton.draw(window)
        self.chooseWhiteButton.draw(window)
    
    def colorMenuClicked(self):
        if self.isClicked == False:
            
            self.isClicked = True
        else:
            
            self.isClicked = False