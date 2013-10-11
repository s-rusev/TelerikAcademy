Function.prototype.inherit = function (parent) {
    this.prototype = new parent();
    this.prototype.constructor = parent;
};

requirejs.config({
     shim: {
         "motion":["libjs","utils","simpleRand"],
         "gameObjects": ["gameEvent","libjs","utils","simpleRand","gameConstants","motion"],
         "gameObjects/GameObject": ["gameObjects"],
         "gameObjects/Asteroid": ["gameObjects/GameObject"],
         "gameObjects/Bullet": ["gameObjects/GameObject"],
         "gameObjects/Ship": ["gameObjects/GameObject"],
         "gameObjects/Enemy": ["gameObjects/GameObject"],
         "gameObjects/ShootingEnemy": ["gameObjects/GameObject"],
         "gameObjects/Shield": ["gameObjects/GameObject"],
         "levelGenerator": ["gameObjects"],
         "gameControler": ["levelGenerator"],
         "user": ["gameObjects","libjs","utils","simpleRand","gameConstants"],
         "ui": ["gameObjects","user", "gameControler","libjs","utils","simpleRand","gameConstants"],
 
     }
 });

require(["libjs"]);
require(["utils"]);
require(["simpleRand"]);

require(["gameConstants"]);
require(["gameObjects"]);
require(["gameObjects/GameObject"]);
require(["gameObjects/Asteroid"]);
require(["gameObjects/Bullet"]);
require(["gameObjects/Ship"]);
require(["gameObjects/Enemy"]);
require(["gameObjects/ShootingEnemy"]);
require(["gameObjects/Shield"]);

require(["motion"]);
require(["gameEvent"]);
require(["gameLevel"]);
require(["levelGenerator"]);
require(["gameControler"]);
require(["user"]);
require(["ui"]);

