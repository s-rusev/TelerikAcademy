<?php
/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: Data Base Connect Class
 * Author: Stamo Petkov
 */

    require_once 'conf.php';
    require_once 'helperFunctions.php';
    
    class TankDB {
        
        private $user = _DB_USER;
        private $pass = _DB_PASSWORD;
        private $dbName = _DB_NAME;
        private $dbHost = _DB_HOST;
        public $con = null;
        
        public function __construct() {
           $this->con = mysql_connect($this->dbHost, $this->user, $this->pass)
               or die ("No connection to DB: " . mysql_error());
           mysql_query("SET NAMES 'utf8'");
           mysql_select_db($this->dbName, $this->con)
               or die ("Unable to change DB: " . mysql_error());
        }
        
        public function register ($data){
            $result = Array();
            $result["error"] = null;         
            // Creating User
            
            $name = mysql_real_escape_string($data["name"]);
            $email = mysql_real_escape_string($data["email"]);
            $password = encrypt($data["password"]);
            $query = "INSERT INTO users (Name, Email, Password) 
                VALUES ('" . $name . "', '" . $email . "', '" . $password . "')";
            if (!mysql_query($query)) {
                $result["error"] = mysql_error($this->con);
            } else {
                $result["userId"] = mysql_insert_id($this->con);
                $result["status"] = "logedin";
            }
            
            // Creating Tank
             
            if ($result["userId"]) {
                $query = "INSERT INTO tank (UserId, Shield, Weapon) 
                    VALUES (" . $result["userId"] . ", '" . $data["shield"] . "', '" . $data["weapon"] . "')";
                if (!mysql_query($query)) {
                    $result["error"] = mysql_error($this->con);
                }
            
            // Creating High Score and Level
            
                $query = "INSERT INTO gameplay (UserId, HighScore, Level) 
                    VALUES (" . $result["userId"] . ", 0, 1)";
                if (!mysql_query($query)) {
                    $result["error"] = mysql_error($this->con);
                }
            }
            
            return $result;
        }

       public function login ($data){
          $result = Array();
          $result["error"] = null;
          $password = encrypt($data["password"]);
          $email = $data["email"];
          $query = "SELECT * FROM users
               WHERE Email = '" . $email . "' AND Password = '" . $password . "' AND Active = 1";
          $res = mysql_query($query);
          if (!$res) {
              $result["error"] = mysql_error($this->con);
          } else if (mysql_num_rows($res) > 0){
              $row = mysql_fetch_assoc($res);
              $result["userId"] = $row["id"];
              $result["name"] = $row["Name"];
              $result["status"] = "logedin";
          }
//          if ($result["userId"]) {
//              $query = "SELECT * FROM tank WHERE UserId = '" . $result["userId"] . "' AND Active = 1";
//              $res = mysql_query($query);
//              if (!$res) {
//                  $result["error"] = mysql_error($this->con);
//              } else if (mysql_num_rows($res) > 0){
//                  $row = mysql_fetch_assoc($res);
//                  $result["shield"] = $row["Shield"];
//                  $result["weapon"] = $row["Weapon"];
//              }
//          }
          return $result;
       }
       
       public function save_tank($data) {
          $result = Array();
          $result["error"] = null;
          $query = "UPDATE tank 
              SET Shield = " . $data["shield"] . ", Weapon = '" . $data["weapon"] . "' 
              WHERE UserId = " . $data["userId"];
          if (!mysql_query($query)) {
              $result["error"] = mysql_error($this->con);
          }
          return $result;
       }
       
       public function save_highscore($data) {
          $result = Array();
          $result["error"] = null;
          $query = "UPDATE gameplay 
              SET HighScore = " . $data["highscore"] . " 
              WHERE UserId = " . $data["userId"];
          if (!mysql_query($query)) {
              $result["error"] = mysql_error($this->con);
          }
          return $result;
       }
       
       public function load_highscore($data) {
          $result = Array();
          $result["error"] = null;
          $query = "SELECT HighScore FROM gameplay WHERE UserId = " . $data["userId"] . " AND Active = 1";
          $res = mysql_query($query);
          if (!$res) {
              $result["error"] = mysql_error($this->con);
          } else {
              $row = mysql_fetch_assoc($res);
              $result["highscore"] = $row["HighScore"];
          }
          return $result;
       }
       
    }
?>
