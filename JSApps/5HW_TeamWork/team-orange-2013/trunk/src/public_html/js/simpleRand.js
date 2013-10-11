// simple, seedable random number generator
// not statistically strong but good enough for
// our purposes
// FIXME: unit test it 

var simpleRand = { };

simpleRand.init = function(seed) {
    seed = Math.floor(seed);
    if (seed < 0) 
        seed *= -1;
    seed += 65537;
    seed *= 65537;
    this.seed = seed;
    this.seed = this.randInt32();
};
simpleRand.randInt32 = function() {
    return this.rand(0, 1 << 31);
};
simpleRand.rand = function(from, to) {
    var ret = +('0.'+Math.sin(this.seed).toString().substr(6));
    this.seed += 1;
    if (isFinite(from) && isFinite(to)) {
        ret = from + ret * (to - from);
    }
    return ret;
};

simpleRand.dice = function(prob) {
    var diceThrow = this.rand();
    return (prob >= diceThrow);
};

simpleRand.init(1);
