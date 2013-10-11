gameObjects.Shield = function(x, y) {
    gameObjects.GameObject.call(this, x, y, 28, 28, true, true, 2);
    this.element.style.backgroundImage = "url(images/shield.png)";
    this.element.style.width = this.width + "px";
    this.element.style.height = this.height + "px";
    this.element.style.display = "block";
    this.positionElement();
};

gameObjects.Shield.inherit(gameObjects.GameObject);


