///// <reference path="jquery-2.0.3.js" />
///// <reference path="class.js" />
//var controls = controls || {};
//(function (c) {
//    var TableView = Class.create({
//        init: function (itemsSource) {
//            if (!(itemsSource instanceof Array)) {
//                throw "The itemsSource of TableView must be an array!";
//            }
//            this.itemsSource = itemsSource;
//        },
//        render: function (template) {
//            var table = document.createElement("table");
//            for (var i = 0; i < this.itemsSource.length; i++) {
//                var tableItem = document.createElement("tr");
//                var item = this.itemsSource[i];
//                tableItem.innerHTML = template(item);
//                table.appendChild(tableItem);

//            }
//            return table.outerHTML;
//        }
//    });

//    c.getTableView = function (itemsSource) {
//        return new TableView(itemsSource);
//    }

//}(controls || {}));

/// <reference path="class.js" />

var controls = controls || {};

(function (controls) {
    var TableView = Class.create({

        init: function (itemsToRender, cols) {
            if (cols == 0) {
                throw "Invalid Arguments cols";
            }

            if (itemsToRender == null) {
                throw "itemsToRender cannot be null";
            }

            if (!(itemsToRender instanceof Array)) {
                throw "itemsToRendermust be instance of Array";
            }

            this.sourceItems = itemsToRender;
            this.cols = cols;
        },
        render: function (template) {
            var table = document.createElement("table");
            var fragment = document.createDocumentFragment();
            fragment.appendChild(table);

            if (this.sourceItems instanceof Array) {
                var tr = document.createElement("tr");

                // interate each sourceitem
                for (var index = 0; index < this.sourceItems.length; index++) {
                    if (index % this.cols == 0 && index != 0) {
                        table.appendChild(tr);
                        tr = document.createElement("tr");
                    }

                    var td = document.createElement("td");
                    td.id = index;
                    var item = this.sourceItems[index];
                    td.innerHTML = template(item);
                    tr.appendChild(td);
                }

                // check last tr if has children
                if (tr.hasChildNodes) {
                    table.appendChild(tr)
                }
            }

            return fragment;
        },

    });

    controls.getTableView = function (itemsToRender, cols) {
        return new TableView(itemsToRender, cols);
    }
}(controls));