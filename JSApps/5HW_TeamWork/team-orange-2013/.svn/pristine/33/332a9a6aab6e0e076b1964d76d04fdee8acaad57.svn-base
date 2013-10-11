function GameEvent(shouldRun, action) {
    this.shouldRun = shouldRun;
    this.action = action;
    this.timesRan = 0;
    this.cancelled = false;
    this.enabled = true;
}

GameEvent.prototype.maybeRun = function(game) {

    if (!this.enabled ||
        this.cancelled)
        return false;
        
    if (!this.shouldRun(game))
        return false;
        
    this.action(game);
    
    this.timesRan += 1;
    
    return true;
    
};

GameEvent.createEventOnceAt = function(when, action) {

    return new GameEvent(function(game) {
        return (game.time === when);
    }, action);
    
};

GameEvent.createEventOnceAtOrLater = function(when, action) {

    var ran = false;
    return new GameEvent(function(game) {
    
        if (ran)
            return false;
            
        if (game.time < when)
            return false;
            
        ran = true;
        
        return true;
        
    }, action);
    
};

GameEvent.createEventPeriodic = function(period, action, prob, times, notBefore, notAfter) {
    
    var first = null;
    return new GameEvent(function(game) {
        if (times) {
            if (times <= 0)
                return false;
            times -= 1;
        }
        
        if (notBefore && game.time < notBefore)
            return false;
            
        if (notAfter && game.time > notAfter)
            return false;
            
        if (prob) {
            if (!simpleRand.dice(prob))
                return false;
        }
            
        if (first === null) {
            first = game.time;
            return true;
        }
        return (((game.time - first) % period) == 0);
    }, action);
    
};












