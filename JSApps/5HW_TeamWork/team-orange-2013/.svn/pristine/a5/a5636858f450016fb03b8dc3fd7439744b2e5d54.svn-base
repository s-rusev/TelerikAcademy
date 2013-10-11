<?php
/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: User Register
 * Author: Stamo Petkov
 */

    require_once 'db.php';

    $db = new TankDB();
    $data = $_REQUEST;
    
    $result = $db->register($data);
    echo json_encode($result);
?>