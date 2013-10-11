utils = {};

// rect1/2 is assumed to be array of left, top, 
// width, and height 
utils.rectanglesMeet = function(rect1, rect2, recurse) {
    if (recurse === undefined)
        recurse = true;
        
    var l1 = rect1[0];
    var l2 = rect2[0];
    var r1 = rect1[0] + rect1[2];
    var r2 = rect2[0] + rect2[2];
    var t1 = rect1[1];
    var t2 = rect2[1];
    var b1 = rect1[1] + rect1[3];
    var b2 = rect2[1] + rect2[3];
    
    if ((l1 >= l2 && l1 <= r2) ||
        (r1 >= l2 && r1 <= r2))
    {
        if ((t1 >= t2 && t1 <= b2) ||
            (b1 >= t2 && b1 <= b2))
            return true;
    }
        
    if (recurse)
        return utils.rectanglesMeet(rect2, rect1, false);
    else
        return false;
};


utils.fromSeconds = function(seconds) {
    return (1000 / gameConstants.UPDATE_INTERVAL_MS) * seconds;
};

utils.inUnitTest = function() {
    return typeof QUnit !== 'undefined'
};

utils.rotate2d = function(base, point, radians) {

    var dx = point[0] - base[0];
    var dy = point[1] - base[1];
    
    var x = base[0] + Math.cos(radians)*dx - Math.sin(radians)*dy;
    var y = base[1] + Math.sin(radians)*dx + Math.cos(radians)*dy;
    
    return [x,y];
    
};

utils.clearChildren = function(node) {
    while (node.hasChildNodes()) {
        node.removeChild(node.lastChild);
    }
};











