levelGenerator = {};

levelGenerator.spawnAt = function(xx, yy) { 
    var action = function(game) {
        game.spawnObject(new gameObjects.ShootingEnemy(xx, yy));
    };
    
    return function(time) {
        return GameEvent.createEventOnceAtOrLater(time, function(game) { action(game); });
    };
};

levelGenerator.periodicMaybeSpawnAt = function(period, xx, yy, prob, times, notBefore, notAfter, spawn) { 
    var action = function(game) {
        var obj = spawn(game, xx, yy);
        if (!obj.motion) {
            obj.motion = Motion.createLine([xx,yy], -1, 0, 10);
        }
        game.spawnObject(obj);
    };
    
    return GameEvent.createEventPeriodic(period, function(game) { action(game); }, prob, times, notBefore, notAfter);
};

levelGenerator.spawnEnemy = function(game, xx, yy) {
    
    var enemy = new gameObjects.ShootingEnemy(xx, yy);

    if (simpleRand.dice(0.13)) {
        enemy.motion = Motion.createLine([xx,yy], -1, 0, 10);
    }
    else if (simpleRand.dice(0.17)) {
        enemy.motion = Motion.createSpiral([xx,yy],50,-1,0,10,1/utils.fromSeconds(2));
    }
    else if (simpleRand.dice(0.25)) {
        enemy.motion = Motion.createLine([xx,yy], -1, +0.45, 10);
    }
    else if (simpleRand.dice(0.33)) {
        enemy.motion = Motion.createLine([xx,yy], -1, -0.45, 10);
    }
    else if (simpleRand.dice(0.5)) {
        enemy.motion = Motion.createSineCurve([xx,yy], 50, 0.01, 0, Math.PI, 10);
    }
    else {
        enemy.motion = Motion.createSineCurve([xx,yy], 20, 0.05, 0, Math.PI, 10);
    }
    
    enemy.startFire(game);
    return enemy;
};

levelGenerator.spawnShield = function(game, xx, yy) {
    return new gameObjects.Shield(xx,yy);
};

levelGenerator.spawnAsteroid = function(game, xx, yy) {
    var ret = new gameObjects.Asteroid(xx,yy);
    ret.motion = Motion.createLine([xx,yy], -1, simpleRand.rand(-0.15, +0.15), 20);
    return ret;
};

levelGenerator.spawnPeriodicSimple = function(seconds, yy, probPerSecond, levelLength, notBeforeSeconds, spawn) {
    return levelGenerator.periodicMaybeSpawnAt(
                utils.fromSeconds(1), 
                gameConstants.FIELD_WIDTH_PX - 50, yy, 
                probPerSecond/utils.fromSeconds(1), 
                null, utils.fromSeconds(notBeforeSeconds), levelLength, spawn);
}

// 0 is debug level
levelGenerator.generateLevel = function(levelNumber) {

    var enemyProb = [1, 0.8, 1.2, 1.6, 2, 2.5][levelNumber]
    var shieldProb = [0, 0.01, 0.01, 0.01, 0.01, 0.01][levelNumber];
    var asteroidProb = [0, 0.3, 0.1, 0.2, 1, 0.4][levelNumber];
    var background =  "url(images/" + ["hyper", "stars", "nova", "hubble-2", "lion", "oranges"][levelNumber] +".jpg)";
    var bulletColor = ["black", "orange", "#CCFF00", "orange", "#CCFF00", "black"][levelNumber];
    
    var length = utils.fromSeconds(gameConstants.DEFAULT_LEVEL_LENGTH_SECONDS);
    
    var level = new GameLevel(length);
    level.background = background;
    level.bulletColor = bulletColor;

    simpleRand.init(levelNumber);
    simpleRand.init(simpleRand.randInt32());
    
    var spawnEnemy = function(yy) {
        if (levelNumber === 0) {
            level.events.push(GameEvent.createEventOnceAtOrLater(
                    utils.fromSeconds(2),
                    function(game) {
                        var enemy = levelGenerator.spawnEnemy(game, gameConstants.FIELD_WIDTH_PX - 50, yy);
                        enemy.motion = Motion.createLine([gameConstants.FIELD_WIDTH_PX - 50,yy], -1, 0, 10);
                        game.spawnObject(enemy);
                    }));
            
        }
        else {
        level.events.push(
            levelGenerator.spawnPeriodicSimple(
                0.5, 
                yy, 
                enemyProb, 
                length, 
                2,
                function(game, xx, yy) { 
                    if (simpleRand.dice(asteroidProb)) 
                        return levelGenerator.spawnAsteroid(game, xx, yy);
                    return levelGenerator.spawnEnemy(game, xx, yy); }
                    ));
        }
    };
    
    var spawnShield = function(yy) {
        level.events.push(
            levelGenerator.spawnPeriodicSimple(
                3, 
                yy, 
                shieldProb, 
                length, 
                10,
                levelGenerator.spawnShield));
    };
    
    
    for(var ii = 50; ii <= 480; ii += 50)
    {
       spawnEnemy(ii);
       if(levelNumber === 0)
           break;
       spawnShield(ii);
    }
    
    return level;
    
};








