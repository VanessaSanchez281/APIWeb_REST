<?php

class db{
    public function conectDB(){
        $contraseña = "123456";
        $usuario = "sa";
        $nombreBaseDeDatos = "Halloween";
# Puede ser 127.0.0.1 o el nombre de tu equipo; o la IP de un servidor remoto
        $rutaServidor = "DESKTOP-82FNAGH";
        try {
            $conexion = new PDO("sqlsrv:server=$rutaServidor;database=$nombreBaseDeDatos", $usuario, $contraseña);
            $conexion->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
            return $conexion;
        } catch (Exception $e) {
            echo "Ocurrió un error con la base de datos: " . $e->getMessage();
        }
    } 
}


?>