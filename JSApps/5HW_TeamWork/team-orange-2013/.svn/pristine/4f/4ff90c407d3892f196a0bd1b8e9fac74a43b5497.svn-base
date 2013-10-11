gameObjects.Bullet = function(x, y, direction, color) {
    gameObjects.GameObject.call(this, x, y, 8, 8, true, true, 0);
    this.direction = direction;
    this.element.style.backgroundColor = color;
    this.element.className = "bullet";
};

gameObjects.Bullet.inherit(gameObjects.GameObject);

gameObjects.Bullet.prototype.onCollision = function(obj) {
    if (obj instanceof gameObjects.Bullet)
        return;
    if (obj instanceof gameObjects.ShootingEnemy &&
        this.owner instanceof gameObjects.ShootingEnemy)
        return;
    gameObjects.GameObject.prototype.onCollision.apply(this, arguments);
};

gameObjects.Bullet.prototype.update = function (game) {
    //TODO: collision detection will be using differences between
    //old and new coordinates
    switch (this.direction) {
        case "right":
            this.x += 20;
            break;
        case "left":
            this.x -= 20;
            break;
        case "up":
            this.y -= 20;
            break;
        case "down":
            this.y += 20;
            break;
        default:
    }
    
    this.positionElement();
    
    this.keepWithinGameField();
};

