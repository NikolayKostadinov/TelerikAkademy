/// <reference path="//Microsoft.WinJS.1.0/js/base.js" />

var PrimeNumbersCalculator = WinJS.Class.define(function() {
    this._workerCount = 0;
}, {
    //workerCount: {
    //    get: function() {
    //         return this._workerCount;
    //    },
    //    set: function (val) {
    //        this._workerCount = val;
    //    }
    //},
    calculatePrimeNumberTo: function(number) {
        var self = this;
        return new WinJS.Promise(function(complete, error) {
            if (self._workerCount < 3) {
                self._workerCount++;
                var worker = Worker("/js/workers/calculatePrimeNumberTo.js");
                worker.onmessage = function(event) {
                    self._workerCount--;
                    var primesList = event.data;
                    complete(primesList);
                };
                worker.postMessage({
                    toNumber: number
                });
            } else {
                error("only 3 workers is allowed at some time");
            }
        });
    },
    calculateFirstNumbers: function(toNumber, stopNumber) {
        var self = this;
        return new WinJS.Promise(function(complete, error) {
            if (self._workerCount < 3) {
                self._workerCount++;
                var worker = Worker("/js/workers/calculateFirstNumbers.js");
                worker.onmessage = function(event) {
                    self._workerCount--;
                    var primesList = event.data;
                    complete(primesList);
                };
                worker.postMessage({
                    toNumber: toNumber,
                    stopNumber: stopNumber
                });
            } else {
                error("only 3 workers is allowed at some time");
            }
        });
    },
    calculateFromRange: function(startNumber, endNumber) {
        var self = this;
        return new WinJS.Promise(function(complete, error) {
            if (self._workerCount < 3) {
                self._workerCount++;
                var worker = Worker("/js/workers/calculateFromRange.js");
                worker.onmessage = function(event) {
                    self._workerCount--;
                    var primesList = event.data;
                    complete(primesList);
                };
                worker.postMessage({
                    startNumber: startNumber,
                    endNumber: endNumber
                });
            } else {
                error("only 3 workers is allowed at some time");
            }
        });
    }
});