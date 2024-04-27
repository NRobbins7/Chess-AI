import pygame

class button():
    def __init__(self, x, y, image):
        self.img = image
        self.rect = self.img.get_rect()
        self.rect.topleft = (x, y)
        self.x = x
        self.y = y
    def draw(self, window):
        window.blit(self.img, (self.rect.x, self.rect.y))
        
