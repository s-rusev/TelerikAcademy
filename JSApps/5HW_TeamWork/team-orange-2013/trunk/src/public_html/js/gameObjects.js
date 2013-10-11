/* 
 * Developed by: Team Orange / Telerik Academy
 * Title: Tank
 * Module: Game Objects
 * Author: Subo Rusev
 */
 
gameObjects = (function () {

    // Objects need to know field size in order to keep within
    
    function setFieldSize(width, height) {
        this.fieldSize = {
            WIDTH: width,
            HEIGHT: height
        };
    }

    return {
        setFieldSize: setFieldSize,
        fieldContainer: null
    };
    
}());

