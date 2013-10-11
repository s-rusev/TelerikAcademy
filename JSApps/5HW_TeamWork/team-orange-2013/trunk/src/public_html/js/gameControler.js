/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Ship
 * Module: Game Controler
 * Author: Velko Nikolov
 */

var gameControler = (function () {
    
    function reset() {
        gameControler.objects = [];
        if (gameControler.playerShip)
            gameControler.playerShip.die(gameControler, false);
        gameControler.time = 0;
    };
    var objects = [];
    var time = 0;
    var timer = 0;
    var correctTime = 0;
    var intervalId;

    function objectCollisionDetect() {
    
        for (j = 0; j < gameControler.objects.length; j++) {
        
            for (k = j + 1; k < gameControler.objects.length; k++) {
            
                var obj1 = gameControler.objects[j];
                var obj2 = gameControler.objects[k];
                
                if (utils.rectanglesMeet(obj1.getRectangle(),
                                         obj2.getRectangle())) {
                    
                    obj1.onCollision(obj2, gameControler);
                    obj2.onCollision(obj1, gameControler);
                    
                } 
                
            }
            
        }
    };
    
    function levelOver(success) {
        gameControler.gameRunning = false;
        clearInterval(gameControler.intervalId);
        
        reset();
        utils.clearChildren(gameObjects.fieldContainer);
        
        if (success) {
            gameControler.levelNumber += 1;
            window.alert("Level completed!");

        }
        else {
            end();
            return;
        }
        
        
        if (gameControler.levelNumber >= 6) {
            window.alert("Game over! Well done!");
        }
        else {
            start();
        }
    };

    function update() {
    
        if (!gameControler.gameRunning)
            return;
            
        gameControler.time += 1;
        timer++;
        if (timer >= 1000 / gameConstants.UPDATE_INTERVAL_MS) {
            correctTime++;
            timer = 0;
        }
        
        $("#points").html(gameControler.points);
        $("#time").html(correctTime);
        
        objectCollisionDetect();
        
        if (gameControler.playerShip.isDestroyed) {
            levelOver(false);
            return;
        }
        
        for (i = 0; i < gameControler.objects.length; i++) {
            var obj = gameControler.objects[i];
            if (obj.isDestroyed) {
                gameControler.objects.splice(i, 1);
                i -= 1;
                if(!utils.inUnitTest())
                {
                    gameObjects.fieldContainer.removeChild(obj.element);
                }

            } else {
                obj.update(gameControler);
            }
        }
        
        for(var ii = 0; ii < gameControler.level.events.length; ++ii) {
            var event = gameControler.level.events[ii];
            if (event.cancelled) {
                gameControler.level.events.splice(ii, 1);
                ii -= 1;
                continue;
            }
            event.maybeRun(gameControler);
        }
        
        if (gameControler.time >= gameControler.level.length) {
        
            if (!libjs.any(gameControler.objects, function(obj) { 
                    if (obj instanceof gameObjects.ShootingEnemy) {
                        return true; 
                    }
                    
                    if (obj instanceof gameObjects.Bullet &&
                        obj.owner instanceof gameObjects.ShootingEnemy) {
                        return true;
                    }
                    
                    return false;
                })) 
            {
                levelOver(true);
                return;
            }
        }
        
    };

    function spawnObject(obj) {
        gameControler.objects.push(obj);
    };
    
    var isInit = false;
    function init() {
        if (isInit)
            return;
        isInit = true;
        
        reset();
        
        $("#container").css(gameFieldStyle = {
            'width': gameConstants.FIELD_WIDTH_PX,
            'height': gameConstants.FIELD_HEIGHT_PX
        });
        
        $(document).ready(function () {
            $("body").on("moveCommand", function(e) { gameControler.playerShip.moveCommand(e); });
            $("body").on("executeCommand", function (e) {
                switch (e.command) {
                    case "start-fire":
                        gameControler.playerShip.startFire(gameControler);
                        break;
                    case "stop-fire":
                        gameControler.playerShip.stopFire(gameControler);
                        break;
                    case "quit":
                        clearInterval(intervalId);
                        break;
                    case "pause":
                        alert("Game paused! Press OK to continue.");
                        break;
                    default:
                    
                }
            });
        });
    }
    
    function end() {
        clearInterval(intervalId);
        $("#container").append('<span class="orange" id="gameOver">GAME OVER</span>');
        $("#gameOver").css({
            position: "relative",
            top: gameConstants.FIELD_HEIGHT_PX / 2 - 20,
            left: gameConstants.FIELD_WIDTH_PX / 2 - 180,
            fontSize: "60px",
            fontWeight: "bold"
        });
        $("#lives").html(0);
    }
    function newGame() {
        clearInterval(intervalId);
        gameControler.lives = 5;
        gameControler.levelNumber = 1;
        gameControler.points = 0;
        correctTime = 0;
        $("#gameOver").remove();
        $("#lives").html(gameControler.lives);
        $("#points").html(gameControler.points);
        $("#time").html(correctTime);
        start();
    }
    

    function start() {
    
        init();
        
        var DEBUG = false;
        if (DEBUG)
            gameControler.levelNumber = 0;
    
        gameObjects.setFieldSize(gameConstants.FIELD_WIDTH_PX, gameConstants.FIELD_HEIGHT_PX);
        gameObjects.fieldContainer = document.querySelector("#container");
        
        gameControler.playerShip = new gameObjects.Ship(20, gameConstants.FIELD_HEIGHT_PX / 2 - 25);

        gameControler.level = levelGenerator.generateLevel(gameControler.levelNumber);
        
        if(gameControler.levelNumber >= 2) {
            gameControler.playerShip.upgrades.push("doubleFire");
        }
        if(gameControler.levelNumber >= 3) {
            gameControler.playerShip.upgrades.push("rapidFire");
        }        
        if(gameControler.levelNumber >= 4) {
            gameControler.playerShip.upgrades.push("speed");
        }
        if(gameControler.levelNumber >= 5) {
            gameControler.playerShip.upgrades.push("rockets");
        }
        
        gameControler.playerShip.bulletColor = gameControler.level.bulletColor || "orange";
        $("#container").css({
            'background': gameControler.level.background,
            'opacity': 0.8
        });
            
        gameControler.playerShip.init();
        gameControler.spawnObject(gameControler.playerShip);
      
        gameControler.gameRunning = true;
        gameControler.intervalId = setInterval(update, gameConstants.UPDATE_INTERVAL_MS);
        
        
    }
    
    return {
        points: 0,
        lives: 5,
        levelNumber: 1,
        start: start,
        end: end,
        newGame: newGame,
        spawnObject: spawnObject
    };
    
}());
