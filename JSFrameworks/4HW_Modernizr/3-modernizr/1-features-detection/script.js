window.addEventListener("load", function() {

    var mainDiv = document.getElementById("main");
    function write(text) {
        var div = document.createElement("div");
        div.innerHtml = text;
        mainDiv.innerHTML += "<div>" + text + "</div>";;
    }
    var uaParser = new UAParser();
    
    var browser = uaParser.getBrowser();
    write("Browser: " + browser.name + " " + browser.version);
    var os = uaParser.getOS();
    write("OS: " + os.name + " " + os.version);
    var device = uaParser.getDevice();
    write("Device: " + device.type + " " + device.model);
    
    var traverse = function (object, prefix) {
        prefix = prefix ? prefix + "." : "";

        for (property in object) {
            if (typeof object[property] == "object") {
                traverse(object[property], prefix + property);
            } else if (typeof object[property] == "boolean") {
                var name = prefix + property;
                var value = object[property] ? "Yes" : "Nope";

                write(name + " -> " + value);
            }
        }
    };

    traverse(Modernizr, "Modernizr");

});