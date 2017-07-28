<?php
    $idSlideMax = 30;
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
        $idSlideNext = $idSlide+1;
        ?>
        <!DOCTYPE HTML>
        <html>
            <head>
                <meta charset="utf-8">
                <title>SlideShow</title>
                <meta http-equiv="Refresh" content="5;url=index.php?ID=<?= $idSlideNext; ?>">
                <link rel="stylesheet" href="style.css">
            </head>
            <body>
                    <!--<?php echo "<li>ID : ".$idSlide." / ".$idSlideMax; ?>-->
                    <div class="element"><img src="<?php echo $slideFile; ?>" width=100%></div>
            </body>
        </html>
        <?php
    } else {
        // n'existe pas on passe à la suivante
        while($idSlide<($idSlideMax+1))
        {
            //echo "<li>ID existe pas : ".$idSlide. " / ".$idSlideMax;
            $idSlide++;
            if ($idSlide>$idSlideMax){$idSlide=1;}
            $slideFile = $slidePath."/slide_".$idSlide.".jpg";    
            $slideFileExists = $slideAbsPath."/".$slidePath."/slide_".$idSlide.".jpg";
            
            //echo "<li>".$slideFile." / ".$slideFileExists;

            if (file_exists($slideFileExists)) {
                //echo "<li>ID EXISTE : ".$slideFile;
                // on bascule vers la page
                $idSlideNext = $idSlide+1;
                ?>
                <!DOCTYPE HTML>
                <html>
                    <head>
                        <meta charset="utf-8">
                        <title>SlideShow</title>
                        <meta http-equiv="Refresh" content="5;url=index.php?ID=<?= $idSlideNext; ?>">
                        <link rel="stylesheet" href="style.css">
                    </head>
                    <body>
                            <!--<?php echo "<li>ID : ".$idSlide." / ".$idSlideMax; ?>-->
                            <div class="element"><img src="<?php echo $slideFile; ?>" width=100%></div>
                    </body>
                </html>
                <?php
                die();
            }
            else {
                // page n'existe pas
                
            }
            
        }
        

    }
?>



