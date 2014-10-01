var Animal = (function () {
    function Animal(fname, species, numberOfLegs) {
        this.fname = fname;
        this.species = species;
        this.numberOfLegs = numberOfLegs;
    }

    Animal.prototype.toString = function () {
        return "Species - " + this.species + ", Name - " + this.fname + ", Legs - " + this.numberOfLegs;
    }

    return Animal;
}());