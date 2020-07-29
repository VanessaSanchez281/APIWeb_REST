<?php
 $ID= "";
 $ShortName = "";
 $LongName = "";
 $mensaje = "";
 if (isset($_GET['search']))
 {    
    $ch = curl_init();
    $api = "http://localhost:1192/api/categories/" .$_GET['search'];
    curl_setopt($ch, CURLOPT_URL, $api);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    $json = curl_exec($ch);    
    curl_close($ch);
    $result = json_decode($json);
    if(!array_key_exists('insertar',$_POST) && !array_key_exists('limpiar',$_POST)){
        $ID = $result->CategoryID;
        $ShortName = $result->ShortName; 
        $LongName = $result->LongName; 
    }       
 } 
 if(array_key_exists('insertar',$_POST)){
    $data = array(
        'CategoryID'      => $_POST['CategoryID'],
        'ShortName'    => $_POST['ShortName'],
        'LongName'       => $_POST['LongName']
      );
    
     $options = array(
        'http' => array(
          'method'  => 'POST',
          'content' => json_encode( $data ),
          'header'=>  "Content-Type: application/json\r\n" .
                      "Accept: application/json\r\n"
          )
      );
      
      $context  = stream_context_create( $options );
      $result = file_get_contents("http://localhost:1192/api/categories/", false, $context );
      $response = json_decode( $result );
      if($response==1){
        $mensaje = "Guardado correctamente";
        $ID= "";
        $ShortName = "";
        $LongName = "";
      }else{
        $mensaje = "Error al guardar";
      }
 }else if(array_key_exists('actualizar',$_POST)){

    $data = array(
        'CategoryID'      => $_POST['CategoryID'],
        'ShortName'    => $_POST['ShortName'],
        'LongName'       => $_POST['LongName']
      );
    $url = "http://localhost:1192/api/categories/" . $_POST['CategoryID'];
    $ch = curl_init($url);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "PUT");
    curl_setopt($ch, CURLOPT_POSTFIELDS,http_build_query($data));    
    $response = curl_exec($ch);
    curl_close($ch); 
    if($response==1){
        $mensaje = "Editado correctamente";
        $ShortName = $_POST['ShortName'];
        $LongName = $_POST['LongName'];
      }else{
        $mensaje = "Error al actualizar";
      }
    
     
 }else if(array_key_exists('eliminar',$_POST)){
    $url = "http://localhost:1192/api/categories/" . $_POST['CategoryID'];
    $ch = curl_init();
    
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_URL, $url);
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "DELETE");
    $result = curl_exec($ch);   
   
    curl_close($ch);    
    if($result==1){
        $mensaje = "Eliminado correctamente";
        $ID= "";
        $ShortName = "";
        $LongName = "";
      }else{
        $mensaje = "Error al eliminar";
      }
    
    
 }else  if(array_key_exists('limpiar',$_POST)){
    $ID= "";
    $ShortName = "";
    $LongName = "";
 }
?>

<!DOCTYPE html>
<html>
<head>
    <title>Mantenimiento de Categorias</title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="Styles/bootstrap.min.css" rel="stylesheet" />
    <link href="Styles/site.css" rel="stylesheet" />
     <script src="Styles/jquery-3.4.1.min.js"></script>
    <script src="Styles/bootstrap.min.js"></script>
 
</head>
<body>

    <div class="container">
        <!-- La imagen se configura en el archivo site.css -->
        <header class="jumbotron"> <img src="Images/banner.jpg" /> </header>
        <main>
            <form id="form1" runat="server" method="post">
                <div class="row">
                    <div class="col-sm-6 table-responsive">
                        <h4>Editar Categorias</h4>
                        <table id="categories" class="table table-bordered tablestriped">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Nombre corto</th>
                                    <th>
                                        Nombre
                                        largo
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                            <?php
                            $ch = curl_init();
                            $api = "http://localhost:1192/api/categories/";
                             curl_setopt($ch, CURLOPT_URL, $api);
                              curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
                           $json = curl_exec($ch);    
                             curl_close($ch);
                            $result = json_decode($json);
  
                            foreach ($result as $result) {
     
                          echo "<tr>";
                         echo "<td><a href=?search=" .$result->CategoryID  .">" .$result->CategoryID ."</a></td><td>" . $result->ShortName . "</td><td>" . $result->LongName . "</td>";
                         echo "</tr>"; 
                         }    
?>
                            </tbody>
                        </table>
                        <span id="message" ><?php echo $mensaje; ?></span>
                    </div>
<div id="details" class="col-lg-6">
                        <input type="hidden" id="orig_id" />
                        <div class="form-group">
                            <label class="control-label">ID</label>
                            <input type="text" id="id" name="CategoryID" value="<?php echo $ID?>" class="form-control" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">Nombre Corto</label>
                            <input type="text" id="short" name="ShortName" value="<?php echo $ShortName?>"class="form-control" />
                        </div>
                        <div class="form-group">
                            <label class="control-label">Nombre Largo</label>
                            <input type="text" id="long" name="LongName" class="form-control" value="<?php echo $LongName?>"/>
                        </div>
                        <div class="form-group">
                            <input type="submit" name="insertar" id="insertar" value="Insertar" class="btn"
                                    />
                            <input type="submit" name="actualizar" id="actualizar" value="Actualizar" class="btn"
                                    />
                            <input type="submit" name="eliminar" id="eliminar" value="Eliminar" class="btn"
                                    />
                            <input type="submit" name="limpiar" id="limpiar" value="Limpiar" class="btn"
                                    />
                        </div>
                    </div>
                    
                </div><!-- fin de la fila (Row) -->
            </form>
        </main>
    </div>
</body>
</html>