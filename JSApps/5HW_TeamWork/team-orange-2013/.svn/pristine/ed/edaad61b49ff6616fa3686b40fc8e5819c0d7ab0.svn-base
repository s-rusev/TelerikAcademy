var SHIP_WIDTH = 60;
var SHIP_HEIGHT = 60;
var SHIP_BULLET_OFFSET_X = 80;

gameObjects.Ship = function(x, y) {
    gameObjects.GameObject.call(this, x, y, SHIP_WIDTH, SHIP_HEIGHT, true, true, 5);
    this.direction = "stop";
    this.baseWidth = this.width;
    this.baseHeight = this.height;
    this.element.style.backgroundImage = "url(images/spaceship.png)";
    this.bullets = [];
    this.upgrades = [];
    this.reloadTime = utils.fromSeconds(1);
    this.destroyable = true;
    this.motionSpeed = 10;
    this.setShieldIndicator();
    this.shieldIndicator.style.left = "8px";
    this.shieldIndicator.style.display = "block";
};

gameObjects.Ship.inherit(gameObjects.GameObject);

gameObjects.Ship.prototype.init = function() {
    if (this.upgrades.indexOf("rapidFire") != -1){
        this.reloadTime = utils.fromSeconds(0.2);
    }
    if (this.upgrades.indexOf("doubleFire") != -1){
        this.doubleFire = true;
    }
    if (this.upgrades.indexOf("speed") != -1) {
        this.motionSpeed = 20;
    }
    if (this.upgrades.indexOf("rockets") != -1) {
        this.firesRockets = true;
    }
};

gameObjects.Ship.prototype.moveCommand = function(evt) {
    this.direction = evt.direction;
};

gameObjects.Ship.prototype.update = function() {

    switch (this.direction) {
        case "right":
            this.x += this.motionSpeed;
            break;
        case "left":
            this.x -= this.motionSpeed;
            break;
        case "up":
            this.y -= this.motionSpeed;
            break;
        case "down":
            this.y += this.motionSpeed;
            break;
        default:
    }
    
    this.x = Math.max(this.x, 20);
    this.x = Math.min(gameObjects.fieldSize.WIDTH - 50, this.x);
    this.y = Math.max(this.y, 0);
    this.y = Math.min(gameObjects.fieldSize.HEIGHT - 50, this.y);
    
    gameObjects.GameObject.prototype.update.apply(this, arguments);
    
};


gameObjects.Ship.prototype.fire = function(game) {

    // var gunShot = new Audio("sounds/Cannon.ogg");
    // gunShot.play();
    
    var me = this;
    var makeBullet = function(dy) { 
        var bullet = new gameObjects.Bullet(me.x + SHIP_BULLET_OFFSET_X, me.y + dy, "right", me.bulletColor);
        bullet.owner = me;
        game.spawnObject(bullet);
    };
    
    if (this.doubleFire) {
        makeBullet(SHIP_HEIGHT / 2 - 20);
        makeBullet(SHIP_HEIGHT / 2 + 16);
    }
    else {
        makeBullet(SHIP_HEIGHT / 2 - 2);
    }
    
    return true;
    
};

gameObjects.Ship.prototype.die = function(game, livelost) {
    
    if (this.isDestroyed)
        return;
        
    var me = this;
    var elem = $(this.element);
    
    if (livelost) {
        gameControler.lives--;
        this.destroyable = false;
        
        elem.toggle("explode", function () {
        
            $("#lives").html(gameControler.lives);
            if (gameControler.lives >= 0) {
                me.isDestroyed = false;
                me.shieldPower = 5;
                me.updateShieldIndicator();
                elem.toggle( "explode", function() {me.destroyable = true;} );
            } else {
                me.isDestroyed = true;
                elem.remove();
            }
                
        });	
    }
    

    

    
};








