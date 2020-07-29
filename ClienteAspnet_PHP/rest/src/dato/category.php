<?php
use Psr\Http\Message\ResponseInterface as Response;
use Psr\Http\Message\ServerRequestInterface as Request;
$app= new \Slim\App;

//Get todas las categorias

$app->get('/api/category',function(Request $request, Response $response){

    $sql = "SELECT * from Categories";
    try {
    $db=new db();
    $db=$db->conectDB();
    $stmt = $db->query($sql);
    if($stmt->rowCount()>0){
    echo json_encode("No existe categorias en la base de datos");
    }else{
        $category=$stmt->fetchAll(PDO::FETCH_OBJ);
        echo json_encode($category);
    }
    $stmt=null;
    $db=null;

    } catch(PDOException $e) {
    echo '{"error":{"text":'. $e->getMessage() .'}}';
    }
}) ;

$app->get('/api/category/{CategoryID}',function(Request $request, Response $response){

    $id_C=$request->getAttribute('CategoryID');
    $sql = "SELECT * from Categories WHERE CategoryID = '".$id_C."'";
    try {
    $db=new db();
    $db=$db->conectDB();
    $stmt = $db->query($sql);
    if($stmt->rowCount()>0){
        echo json_encode("No existe categorias en la base de datos");
    }else{
        $category=$stmt->fetchAll(PDO::FETCH_OBJ);
    echo json_encode($category);
    }
    $stmt=null;
    $db=null;

    } catch(PDOException $e) {
    echo '{"error":{"text":'. $e->getMessage() .'}}';
    }
}) ;

$app->post('/api/category/nuevo',function(Request $request, Response $response){

    $CategoryID=$request-> getParam('CategoryID');
    $ShortName=$request-> getParam('ShortName');
    $LongName=$request-> getParam('LongName');
    $sql = "INSERT INTO Categories(CategoryID,ShortName,LongName) VALUES(:CategoryID,:ShortName,:LongName)";
    try {
    $db=new db();
    $db=$db->conectDB();
    $stmt = $db->prepare($sql);   
    $stmt->bindParam(':CategoryID',$CategoryID);    
    $stmt->bindParam(':ShortName',$ShortName);    
    $stmt->bindParam(':LongName',$LongName);   
    $stmt->execute();
    echo json_encode("Cliente Guardado");
    $stmt=null;
    $db=null;

    } catch(PDOException $e) {
    echo '{"error":{"text":'. $e->getMessage() .'}}';
    }
}) ;



$app->put('/api/category/actualizar/{CategoryID}',function(Request $request, Response $response){

    $id_C=$request->getAttribute('CategoryID');
    $ShortName=$request-> getParam('ShortName');
    $LongName=$request-> getParam('LongName');
    $sql = "UPDATE  Categories SET 
    ShortName=:ShortName,
    LongName=:LongName
    WHERE CategoryID='".$id_C."'";
    try {
    $db=new db();
    $db=$db->conectDB();
    $stmt = $db->prepare($sql);
    $stmt->bindParam(':ShortName',$ShortName);    
    $stmt->bindParam(':LongName',$LongName);   
    $stmt->execute();
    echo json_encode("Cliente Actualizado");
    $stmt=null;
    $db=null;

    } catch(PDOException $e) {
    echo '{"error":{"text":'. $e->getMessage() .'}}';
    }
}) ;


$app->delete('/api/category/eliminar/{CategoryID}',function(Request $request, Response $response){

    $id_C=$request->getAttribute('CategoryID');
    $sql = "DELETE FROM Categories WHERE CategoryID = '".$id_C."'";
    try {
    $db=new db();
    $db=$db->conectDB();
    $stmt = $db->prepare($sql);
    $stmt->execute();
    if( $stmt->rowCount()>0){
        echo json_encode("Cliente Eliminado");
    }else{
        echo json_encode("Cliente No Eliminado");
    }
  
    $stmt=null;
    $db=null;

    } catch(PDOException $e) {
    echo '{"error":{"text":'. $e->getMessage() .'}}';
    }
}) ;



