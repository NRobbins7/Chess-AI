import pygame
import chess

from newBoard import board
from menu import menu
from square import square
pygame.init()

gameWindowSize = (800,600)
gameWindow = pygame.display.set_mode(gameWindowSize)

running = True
onMenu = True
onGamePVP = False
onGameAI = False
onColorSelectMenu = False

playerColor = 'white'

legalSquares = None
activesquare = None
start = None
end = None
startMenu = menu()

while running == True:
    gameBoard = board()
    while onMenu == True:
        
        startMenu.backgroundDraw.draw(gameWindow)
        startMenu.draw_menu(gameWindow)
        for event in pygame.event.get():
            if event.type == pygame.MOUSEBUTTONDOWN:
                mousepos = pygame.mouse.get_pos()
                if startMenu.startGameButton.rect.collidepoint(mousepos):
                    onMenu = False
                    onGamePVP = True
                elif startMenu.startAIButton.rect.collidepoint(mousepos):
                    onMenu = False
                    onColorSelectMenu = True
                    onGameAI = True
                elif startMenu.colorMenuOpenButton.rect.collidepoint(mousepos):
                    startMenu.colorMenuClicked()
                if startMenu.isClicked == True:
                    if startMenu.redpinkButton.rect.collidepoint(mousepos):
                        gameBoard.color = 1
                        startMenu.isClicked = False
                    elif startMenu.whiteblackButton.rect.collidepoint(mousepos):
                        gameBoard.color = 0
                        startMenu.isClicked = False
                    elif startMenu.greenblueButton.rect.collidepoint(mousepos):
                        gameBoard.color = 2
                        startMenu.isClicked = False
                    elif startMenu.orangeyellowButton.rect.collidepoint(mousepos):
                        gameBoard.color = 3
                        startMenu.isClicked = False
                    elif startMenu.brownbeigeButton.rect.collidepoint(mousepos):
                        gameBoard.color = 4
                        startMenu.isClicked = False
                    elif startMenu.navyturquoiseButton.rect.collidepoint(mousepos):
                        gameBoard.color = 5
                        startMenu.isClicked = False
            pygame.display.flip()
    
    gameBoard.drawBoard()
    while onGamePVP == True:
        
        gameWindow.fill((120,120,120))
        gameBoard.drawBoardWindow(gameWindow, None)

        if gameBoard.gameIsOver == True:
            gameBoard.getEnding(gameWindow)
            
        for event in pygame.event.get():
            if event.type == pygame.MOUSEBUTTONDOWN:
                if gameBoard.gameIsOver == False:
                    mousepos = pygame.mouse.get_pos()
                    for squares in gameBoard.grid:
                        if(squares.drawRect.collidepoint(mousepos)):
                            if(squares.pieceOn != None) and (squares.pieceOn.color == gameBoard.turn):
                                start = squares.getUCI(gameBoard.turn)
                                activesquare = squares
                                activesquare.active = True
                else:
                    if startMenu.rematchButton.rect.collidepoint(pygame.mouse.get_pos()):
                        start = None
                        end = None
                        gameBoard.newGame()
                    elif startMenu.toMenuButton.rect.collidepoint(pygame.mouse.get_pos()):
                        onMenu = True
                        onGamePVP = False
                        onGameAI = False
            if event.type == pygame.MOUSEMOTION:
                if activesquare != None:
                    gameBoard.drawBoardWindow(gameWindow, gameBoard.getLegalSquares(activesquare.num, gameBoard.flipped))
                    activesquare.active = True
                    mos = pygame.mouse.get_pos()
                    xpos = mos[0] - (511/8)/2
                    ypos = mos[1] - (511/8)/2
                    gameWindow.blit(activesquare.pieceOn.img, (xpos, ypos))
            if event.type == pygame.MOUSEBUTTONUP:
                activesquare = None
                if start != None:
                    for squares in gameBoard.grid:
                        if(squares.drawRect.collidepoint(pygame.mouse.get_pos())):
                            end = squares.getUCI(gameBoard.turn)
                            move =  start + end
                    if start != None and end != None and start != end:
                        gameBoard.makeMove(move, gameWindow, False)
                        start = None
                        end = None
                gameBoard.drawBoard()
                    

            pygame.display.flip()

    while onGameAI == True:
        gameWindow.fill('gray')
        gameBoard.drawBoardWindow(gameWindow, None)
        if onColorSelectMenu == True:
            startMenu.chooseColor(gameWindow)
        
        
        for event in pygame.event.get():
            if event.type == pygame.MOUSEBUTTONDOWN:
                if onColorSelectMenu == True:
                    if startMenu.chooseWhiteButton.rect.collidepoint(pygame.mouse.get_pos()):
                        onColorSelectMenu = False
                        playerColor = 'white'
                    elif startMenu.chooseBlackButton.rect.collidepoint(pygame.mouse.get_pos()):
                        onColorSelectMenu = False
                        playerColor = 'black'
                        gameBoard.flipped = True
                else:
                    if gameBoard.gameIsOver == False:
                        if playerColor == gameBoard.turn:
                            mousepos = pygame.mouse.get_pos()
                            for squares in gameBoard.grid:
                                if(squares.drawRect.collidepoint(mousepos)):
                                    if(squares.pieceOn != None) and (squares.pieceOn.color == gameBoard.turn):
                                        start = squares.getUCI(gameBoard.turn)
                                        activesquare = squares
                                        activesquare.active = True
                    else:
                        if startMenu.rematchButton.rect.collidepoint(pygame.mouse.get_pos()):
                            start = None
                            end = None
                            gameBoard.newGame()
                        elif startMenu.toMenuButton.rect.collidepoint(pygame.mouse.get_pos()):
                            onMenu = True
                            onGamePVP = False
                            onGameAI = False
                            startMenu.isClicked = False
            if event.type == pygame.MOUSEMOTION:
                if activesquare != None:
                    gameBoard.drawBoardWindow(gameWindow, gameBoard.getLegalSquares(activesquare.num, gameBoard.flipped))
                    activesquare.active = True
                    mos = pygame.mouse.get_pos()
                    xpos = mos[0] - (511/8)/2
                    ypos = mos[1] - (511/8)/2
                    gameWindow.blit(activesquare.pieceOn.img, (xpos, ypos))
            if event.type == pygame.MOUSEBUTTONUP:
                activesquare = None 
                if start != None:
                    for squares in gameBoard.grid:
                        if(squares.drawRect.collidepoint(pygame.mouse.get_pos())):
                            end = squares.getUCI(gameBoard.turn)
                            move =  start + end
                    if start != None and end != None and start != end:
                        gameBoard.makeMove(move, gameWindow, True)
                        start = None
                        end = None
                gameBoard.drawBoard()
        
            pygame.display.flip()