<?php
/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: User Save Tank
 * Author: Stamo Petkov
 */

    require_once 'db.php';

    $db = new TankDB();
    $data = $_REQUEST;
    
    $result = $db->save_tank($data);
    echo json_encode($result);
?>