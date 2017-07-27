<?php
    $idSlideMax = 18;
    $slidePath = "slides";
    $slideAbsPath = getcwd();
    $idSlide = $_GET['ID'];
    
    // vérifie si idSlide existe ou ne depasse pas la limite idSlideMax
    if ($idSlide<1 OR $idSlide>$idSlideMax)
    {
        $idSlide=1;
    }
    
    // vérifie si le fichier existe  
    $slideFile = $slidePath."/slide_".$idSlide.".jpg";    
    $slideFileExists = $slideAbsPath."/".$slidePath."/slide_".$idSlide.".jpg";
    
    if (file_exists($slideFileExists)) {
        // existe, on affiche l'image
        //echo "Le fichier existe.";
        $idSlideNext = $idSlide+1;
    } else {
        // n'existe pas on passe à la suivante
        //echo "Le fichier n'existe pas.";
        $idSlide++;
        $idSlideNext = $idSlide;
    }
?>
<!DOCTYPE HTML>
<html>
    <head>
        <meta charset="utf-8">
        <title>SlideShow</title>
        <meta http-equiv="Refresh" content="5;index.php?ID=<?= $idSlideNext; ?>">
        <link rel="stylesheet" href="style.css">
    </head>
    <body>
            <div class="element"><img src="<?php echo $slideFile; ?>" width=100%></div>
    </body>
</html>


