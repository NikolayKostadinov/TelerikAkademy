/// <reference group="Dedicated Worker" />
var isPrime = function(number) {
    for (var i = 2; i < number; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
};

var calculatePrimes = function(toNumber, stopNumber) {
    var primesList = new Array();

    for (var ind = 1; ind < toNumber; ind++) {
        if (isPrime(ind)) {
            if (primesList.length < stopNumber) {
                primesList.push(ind);
            } else {
                break;
            }
        }
    }

    return primesList;
};

onmessage = function(event) {
    var result = calculatePrimes(event.data.toNumber, event.data.stopNumber);

    postMessage(result);
};
