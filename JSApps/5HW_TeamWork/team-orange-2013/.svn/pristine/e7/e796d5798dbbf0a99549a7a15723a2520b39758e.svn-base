gameObjects.ShootingEnemy = function(x,y) {
    gameObjects.Enemy.call(this, x, y, 50, 50, true, true, 2);
    this.element.style.backgroundImage = "url(images/enemy.png)";
    this.reloadTime = utils.fromSeconds(1.5);
};

gameObjects.ShootingEnemy.inherit(gameObjects.Enemy);

gameObjects.ShootingEnemy.prototype.onCollision = function(obj) {
    if (obj instanceof gameObjects.ShootingEnemy)
        return;
        
    if (obj instanceof gameObjects.Bullet &&
        obj.owner instanceof gameObjects.ShootingEnemy)
        return;
        
    gameObjects.GameObject.prototype.onCollision.apply(this, arguments);
};

gameObjects.ShootingEnemy.prototype.fire = function(game) {
    //var laser = new Audio("sounds/Laser.ogg");
    //laser.play();
    var bullet = new gameObjects.Bullet(this.x - 12, this.y + 7, "left", "red");
    bullet.owner = this;
    game.spawnObject(bullet);
};
