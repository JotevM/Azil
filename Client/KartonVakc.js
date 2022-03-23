export class KartonVakc
{
    constructor(id, nazivVakcine, datumVakcinacije){
        this.id = id;
        this.nazivVakcine = nazivVakcine;
        this.datumVakcinacije = datumVakcinacije;
    }

    crtaj(host){
        
        var tr = document.createElement("tr");
        host.appendChild(tr);

        var el = document.createElement("td");
        el.innerHTML = this.nazivVakcine;
        tr.appendChild(el);

        el = document.createElement("tr");
        el.innerHTML = this.datumVakcinacije;
        tr.appendChild(el);
    }
}