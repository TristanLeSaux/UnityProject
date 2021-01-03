Ce qui a été intégré :
	Un menu, contenant :
		-Un bouton pour lancer le premier niveau.
		-Les scores (Les 10 meilleurs scores sont enregsitré).
		-Un menu Option (pour changer le volume sonore du jeu).
		-Un bouton pour quitter le jeu.
	
	Deux niveaux :
		-Un niveau de base avec des astéroïdes comme ennemis,
		avec une augmentation de la difficulté dans le temps.
		
		-Un niveau avec un Boss : des ennemis avec des pattern différents.
		
	Un SoundManager, pour gérer les bruitages et les musiques (qui ne se relance pas quand on relance le niveau),
	et un GameManager (qui gère le score), tout deux Singleton.
		
		
		
		
Ce qui aurait dû être intégré :
	Des niveaux supplémentaires (Une base de niveau est présente pour faciliter leur création),
	Des ennemis supplémentaires (Des prefab et des textures sont déjà présent),
	
	Les crédits : même si les textures et les musiques sont libres de droits,
leurs auteurs aimeraient, si possible, être affiché dans des crédits.

	Des sons : 
		Quand le joueur est touché.
		Quand le joueur meurt.
		Quand un ennemis meurt.
		Quand le boss meurt.
		Quand le joueur gagne (level Boss).
		
	Des animations :
		Quand un ennemi ou le joueur meurt. (Explosion)
		Un changement d'animation quand le joueur accélère.
		Une transition plus lente entre les scènes.
	
	Un changement de difficulté :
		Je n'ai pas implémenté correctement les movements, ceux-ci sont variables en fonction du support,
la difficulté a donc été diminué pour permettre de jouer correctement sur tout support
(le premier niveau se finit après avoir marqué 30 points).
Le jeu se finit très rapidement sur certains support.

	Cela n'a pas été intégré par manque de temps : à cause d'autres projets/examens,
ou par une mauvaise organisation de ma part.

	Il y'a beaucoup de textures non-utilisées, et beaucoup de place sur le SpriteSheet :
	J'ai commencé à utiliser ces textures assez tôt, sans savoir lesquels ne le seraient pas.
	Celles-ci pourront être utilisées dans de futurs versions du projets.
	
	Il y'a beaucoup de script qui se ressemble, cela est dû à une mauvaise organisation de ma part,
j'aurais dû prendre le temps de noter ce qu'allait faire chaque script, et où les placer,
pour ensuite ajouter, par exmple, des paramètres à ces script, permettant de les réutiliser,
notamment pour le laser du joueur et celui des ennemis.

	Je devrais également "Harmoniser" les textures : j'ai récupérer diverses textures,
libres de droits, et certaines ne sont pas en accord avec les autres, que ce soit au niveau des couleurs ou des ombres.



	Les difficultés rencontrées :
		Les textures utilisées faisaient apparaîtres des lignes autour d'elles :
		en retirant l'anti aliasing les lignes disparaissent.

	J'ai rencontrés un certains nombre de soucis de ce genre, mais la communauté Unity étant assez conséquente,
on trouve aisément des solutions/Tuto sur Internet.

	J'ai également demandé un peu d'aide à certains camarades.



