/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: User
 * Author: Stamo Petkov
 */

var user = (function() {
    var Weapons = Object.freeze({
            BULLETS: "bullets",
            ROCKETS: "rockets"
        }),
        Status = Object.freeze({
            LOGED: "loged",
            NOTLOGED: "notloged",
            ANONIMOUS: "anonimous"
        });
    
    function User (){
       this.name = "";
       this.email = "";
       this.password = "";
       this.status = Status.NOTLOGED;
       this.userId = 0;
       this.tank = {
           shield: 5,
           weapon: Weapons.BULLETS
       };
       this.level = 1;
       this.highScore = 0;
   }
   
   User.prototype.login = function(email, password) {
       $.post('handlers/userLogin.php', {
           email: email,
           password: password
       }, function(data) {
           var result = JSON.parse(data);
           $("#registerMessage").html("Hello, " + result["name"]);
       });
   };
   
   User.prototype.register = function(name, email, password) {
       $.post('handlers/userRegister.php', {
           name: name,
           email: email,
           password: password
       }, function(data) {
           var result = JSON.parse(data);
           $("#registerMessage").html("Hello, " + name);
           this.userId = result["userId"];
           this.status = result["status"];
       });
   };
   
   User.prototype.saveTank = function() {
       
   };
   
   User.prototype.saveHighScore = function() {
       
   };
   
   return {
       Player: User
   }
   
}());

