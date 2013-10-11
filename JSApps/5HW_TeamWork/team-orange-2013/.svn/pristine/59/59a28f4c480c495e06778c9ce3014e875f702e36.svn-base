<?php
/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: Load High Score
 * Author: Stamo Petkov
 */

    require_once 'db.php';

    $db = new TankDB();
    $data = $_REQUEST;
    
    $result = $db->load_highscore($data);
    echo json_encode($result);
?>