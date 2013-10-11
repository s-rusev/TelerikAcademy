gameObjects.Enemy = function(x, y) {
    gameObjects.GameObject.call(this, x, y, 50, 50, true, true, 2);
    this.element.style.backgroundImage = "url(images/enemy.png)";

};

gameObjects.Enemy.inherit(gameObjects.GameObject);


