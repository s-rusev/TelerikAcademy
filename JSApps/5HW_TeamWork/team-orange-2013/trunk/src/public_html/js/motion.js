function Motion(func) {
    this.beginning = null;
    this.func = func;
    this.paused = false;
    this.last = null;
};

Motion.prototype.getLocation = function(time) {

    if (this.paused)
        return this.last;

    if (this.beginning === null)
        this.beginning = time;
        
    var delta = time - this.beginning;
    this.last = this.func(delta);

    return this.last;
};


Motion.createLine = function(base, dx, dy, speed) {
    var motion = new Motion(function(time) {
        var x = time * dx * speed;
        var y = time * dy * speed;
        return [base[0]+x,base[1]+y];
    });
    
    return motion;
};

Motion.createRandomCurve = function(point, xRandom, yRandom) {
    throw new Error("not implemented");

};

Motion.createZigZagCurve = function(point, xRandom, yRandom) {
    throw new Error("not implemented");

};

// angularSpeed - revolutions per unit time
// too slow and it becomes a deformed sine curve
Motion.createSpiral = function(base, radius, dx, dy, centerSpeed, angularSpeed) {

    var motion = new Motion(function(time) {
        var centerX = time * dx * centerSpeed;
        var centerY = time * dy * centerSpeed;
        
        var angle = 2*Math.PI*angularSpeed*time;
        
        var x = centerX + Math.cos(angle)*radius;
        var y = centerY + Math.sin(angle)*radius;
        
        return [base[0]+x,base[1]+y];
    });
    
    return motion;
};

Motion.createRandomizedMotion = function(motion, randomFactor) {
    throw new Error("not implemented");
};


// x ~ t
// y = a*sin(b*x + p)
Motion.createSineCurve = function(base, a, b, p, direction, speed) {

    var motion = new Motion(function(time) {
        var x = time * speed;
        var y = a*Math.sin(b*x + p);
        return utils.rotate2d(base, [base[0]+x,base[1]+y], direction);
    });
    
    return motion;
    
};
