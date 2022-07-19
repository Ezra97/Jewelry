class Item {
    constructor() { }
    ID: number;
    Name: string;
    Descriptoin: string;
}
class Group extends Item {
}
class Jewel extends Item {
}

function Hello(h: HTMLInputElement) {
    let option = document.createElement("option");
    option.text = h.value;
    let select = document.getElementById("selectID");
    select.appendChild(option);

}


function ShowGroup(g: HTMLInputElement) {
    window.location.href = "/home/index/" + g.nodeValue;
}

function Search(s: string, groups: Array<Group>, jewels: Array<Jewel>) {

    



    let Items: Array<Item> = SearchI(s, groups, jewels);
    let li = document.getElementById("liID");
    li.removeChild(document.getElementById("selectID"));
    let select = document.createElement("select");
    select.id = "selectID";
    
    li.appendChild(select);
    
    for (var i = 0; i < Items.length; i++) {
        let option = document.createElement("option");
        option.value = Items[i].ID.toString();
        option.text = Items[i].Name;
        
        select.appendChild(option);
    }
    select.addEventListener("select", Choice);
}
function Choice() {   
   // window.location.href = 'Url.Action("Index", "Home")';
    window.location.href = "/home/index/"+document.getElementById("selectID").nodeValue;
}
function SearchI(s: string, groups: Array<Group>, jewels: Array<Jewel>): Array<Item>{
    let Items: Array<Item>;
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
function Exists(s: string, text: string): boolean {
    if (text.search(s) != -1)
        return true;
    return false;
}