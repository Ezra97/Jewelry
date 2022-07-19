var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        if (typeof b !== "function" && b !== null)
            throw new TypeError("Class extends value " + String(b) + " is not a constructor or null");
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Item = /** @class */ (function () {
    function Item() {
    }
    return Item;
}());
var Group = /** @class */ (function (_super) {
    __extends(Group, _super);
    function Group() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Group;
}(Item));
var Jewel = /** @class */ (function (_super) {
    __extends(Jewel, _super);
    function Jewel() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    return Jewel;
}(Item));
function Hello(h) {
    var option = document.createElement("option");
    option.text = h.value;
    var select = document.getElementById("selectID");
    select.appendChild(option);
}
function ShowGroup(g) {
    window.location.href = "/home/index/" + g.nodeValue;
}
function Search(s, groups, jewels) {
    var Items = SearchI(s, groups, jewels);
    var li = document.getElementById("liID");
    li.removeChild(document.getElementById("selectID"));
    var select = document.createElement("select");
    select.id = "selectID";
    li.appendChild(select);
    for (var i = 0; i < Items.length; i++) {
        var option = document.createElement("option");
        option.value = Items[i].ID.toString();
        option.text = Items[i].Name;
        select.appendChild(option);
    }
    select.addEventListener("select", Choice);
}
function Choice() {
    // window.location.href = 'Url.Action("Index", "Home")';
    window.location.href = "/home/index/" + document.getElementById("selectID").nodeValue;
}
function SearchI(s, groups, jewels) {
    var Items;
    for (var i = 0; i < groups.length; i++) {
        if (Exists(s, groups[i].Name)) {
            Items.push(groups[i]);
        }
    }
    for (var i = 0; i < jewels.length; i++) {
        if (Exists(s, jewels[i].Name)) {
            Items.push(jewels[i]);
        }
    }
    return Items;
}
function Exists(s, text) {
    if (text.search(s) != -1)
        return true;
    return false;
}
//# sourceMappingURL=search.js.map