var PrimeNumbersCalculator = WinJS.Class.define(function() {

}, {
    calculatePrimeNumberTo: function(number) {
        return new WinJS.Promise(function (complete) {
            var primesList = new Array();

            for (var ind = 1; ind < number; ind++) {
                if (isPrime(ind)) {
                    primesList.push(ind);
                }
            }

            complete(primesList);
        });
    },
    calculateFirstNumbers: function(toNumber, stopNumber) {
        return new WinJS.Promise(function (complete) {
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

            complete(primesList);
        });
    },
    calculateFromRange: function(startNumber, endNumber) {
        return new WinJS.Promise(function (complete) {
            var primesList = new Array();

            for (var ind = startNumber; ind < endNumber; ind++) {
                if (isPrime(ind)) {
                    primesList.push(ind);
                }
            }

            complete(primesList);
        });
    }
});

var isPrime = function (number) {
    for (var i = 2; i < number; i++) {
        if (number % i == 0) {
            return false;
        }
    }
    return true;
}