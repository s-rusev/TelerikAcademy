// Abstract class, representing game objects
gameObjects.GameObject = function(x, y, width, height, destroyable, movable, shieldPower) {
    this.x = x;
    this.y = y;
    this.width = width;
    this.height = height;
    this.destroyable = destroyable;
    this.movable = movable;
    this.isDestroyed = false;
    this.shieldPower = shieldPower;
    this.fullShieldPower = shieldPower;
    this.element = document.createElement("div");
    this.element.style.position = "absolute";
    // Moved here, because all objects must be apended
    if (gameObjects.fieldContainer) {
        gameObjects.fieldContainer.appendChild(this.element);
    }
    
    this.element.style.width = this.width + "px";
    this.element.style.height = this.height + "px";
    this.element.style.display = "block";
    
    this.element.style.top = this.y + "px";
    this.element.style.left = this.x + "px";
    // this.positionElement();
}

gameObjects.GameObject.prototype.getRectangle = function() {
    return [this.x, this.y, this.width, this.height];
};

gameObjects.GameObject.prototype.setShieldIndicator = function () {
    var shieldProgress = document.createElement("div"),
        shieldContainer = document.createElement("div");
    

    shieldProgress.className = "shieldProgress";
    shieldContainer.style.position = "relative";
    shieldContainer.appendChild(shieldProgress);
    this.element.appendChild(shieldContainer);
    this.shieldIndicator = shieldProgress;
    
    this.shieldIndicator.style.display = "none";
}

gameObjects.GameObject.prototype.die = function(game, animate) {
    this.isDestroyed = true;
    
    if(this.fireEvent) {
        this.fireEvent.cancelled = true;
    }
        

    if (!animate) {
        this.element.style.display = "hidden";
    }
    if(animate && this.isInGameField()) {
        var jQueryElement = jQuery(this.element);
        jQueryElement.effect("explode", function () {
            jQueryElement.remove();
        });
    }
    
};

gameObjects.GameObject.prototype.positionElement = function () {
    this.element.style.top = this.y + "px";
    this.element.style.left = this.x + "px";
};

gameObjects.GameObject.prototype.update = function (game) {
    if (this.motion) {
        var pt = this.motion.getLocation(game.time);
        this.x = pt[0];
        this.y = pt[1];
    }
    
    this.positionElement();
    
    this.keepWithinGameField();

}

gameObjects.GameObject.prototype.onCollision = function (obj, game) {
    if (this.isDestroyed)
        return;
        
    if (this.destroyable) {
        this.shieldPower--;
        
        if (this.shieldPower < 0) {
            if (this instanceof gameObjects.Enemy &&
                obj instanceof gameObjects.Bullet &&
                obj.owner instanceof gameObjects.Ship) {
                gameControler.points += 20;
            }
            
            // var explosion = new Audio("sounds/Explosion.ogg");
            // explosion.play();
            
            this.die(game, true);
        } else {
            if(this.shieldIndicator) {
                this.updateShieldIndicator();
            }
        }
    }
}

gameObjects.GameObject.prototype.updateShieldIndicator = function() {
                this.shieldIndicator.style.width = 
                    20 - (20 / this.fullShieldPower * (this.fullShieldPower - this.shieldPower)) + "px";
};

gameObjects.GameObject.prototype.keepWithinGameField = function() {
    if (gameObjects.fieldSize !== null) {
        if (!this.isInGameField()) {
            this.die(gameControler, false);
            return;
        }
            
    } else {
        throw new Error("Unknown game field size. Please use setFieldSize() to set it.");
    }
}



gameObjects.GameObject.prototype.startFire = function(game) {
    if (!this.fireEvent) {
        var me = this;
        
        this.fireEvent = GameEvent.createEventPeriodic(
            this.reloadTime, 
            function(game) { me.fire(game) });
                   
        game.level.events.push(this.fireEvent);
    }
};

gameObjects.GameObject.prototype.stopFire = function(game) {
    
    if (!this.fireEvent)
        return;
        
    this.fireEvent.cancelled = true;
    this.fireEvent = null;
    
};

gameObjects.GameObject.prototype.isInGameField = function () {
    var result = true;
    if (this.x < 0 || this.x > gameObjects.fieldSize.WIDTH || this.y < 0 || this.y > gameObjects.fieldSize.HEIGHT) {
        result = false;
    }

    return result;
};







