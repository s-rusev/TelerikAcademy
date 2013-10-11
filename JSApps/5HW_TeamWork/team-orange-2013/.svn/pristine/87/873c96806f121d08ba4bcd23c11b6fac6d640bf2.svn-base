setTimeout(function() { test("Game objects creation tests", function () {
    var shipTest = new gameObjects.Ship(100, 100);

     ok(shipTest.x === 100, "Ship passed x coord test!");
     ok(shipTest.y === 100, "Ship passed y coord test!");
     ok(shipTest.destroyable === true, "Ship passed destroyable test test!");
     ok(shipTest.width === 60, "Ship passed width test!");
     ok(shipTest.height === 60, "Ship passed height test!");
     ok(shipTest.direction === "stop", "Ship passed direction test!");
     ok(shipTest.shieldPower === 5, "Ship passed shield power test!");
 
     //moving test
     gameObjects.setFieldSize(1000, 550);
    // gameObjects.fieldContainer(document.querySelector("#container"));
     shipTest.direction = "right";
     shipTest.update();
     ok(shipTest.x === 110, "Ship moving right passed test!");
 
     shipTest.direction = "left";
     shipTest.update();
     ok(shipTest.x === 100, "Ship moving left passed test!");
 
     shipTest.direction = "up";
     shipTest.update();
     ok(shipTest.y === 90, "Ship moving up passed test!");
 
     shipTest.direction = "down";
     shipTest.update();
     ok(shipTest.y === 100, "Ship moving down passed test!");
 
     shipTest.direction = "right";
     shipTest.update();
     ok(shipTest.x === 110, "Ship moving right passed test!");  
     
     var enemyTest = new gameObjects.Enemy(200, 200);
 
     ok(enemyTest.x === 200, "Enemy passed x coord test!");
     ok(enemyTest.y === 200, "Enemy passed y coord test!");
     ok(enemyTest.destroyable === true, "Enemy passed destroyable test!");
     ok(enemyTest.width === 50, "Enemy passed width test!");
     ok(enemyTest.height === 50, "Enemy passed height test!")
     ok(enemyTest.shieldPower === 2, "Enemy passed shield power test!");
 
     var shootingEnemyTest = new gameObjects.ShootingEnemy(310, 310);
 
     ok(shootingEnemyTest.x === 310, "Shooting enemy passed x coord test!");
     ok(shootingEnemyTest.y === 310, "Shooting enemy passed y coord test!");
     ok(shootingEnemyTest.destroyable === true, "Shooting enemy passed destroyable test!");
     ok(shootingEnemyTest.width === 50, "Shooting enemy passed width test!");
     ok(shootingEnemyTest.height === 50, "Shooting enemy passed height test!")
     ok(shootingEnemyTest.shieldPower === 2, "Shooting enemy passed shield power test!");
 
     shootingEnemyTest.motion = Motion.createLine([310,310], -1, 0, 5);
     shootingEnemyTest.update({time:0});
     shootingEnemyTest.update({time:1});
     ok(shootingEnemyTest.x === 305, "Shooting enemy move left pass!");
     
     /* removed old bullet test - Velko, 2013-06-17 02:03:52 */
});}, 1000);





