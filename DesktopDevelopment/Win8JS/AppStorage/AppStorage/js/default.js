// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkId=232509
(function () {
    "use strict";

    WinJS.Binding.optimizeBindingReferences = true;

    var app = WinJS.Application;
    var activation = Windows.ApplicationModel.Activation;

    var localFolder = Windows.Storage.ApplicationData.current.localFolder;
    
    app.onactivated = function (args) {
        if (args.detail.kind === activation.ActivationKind.launch) {
            if (args.detail.previousExecutionState !== activation.ApplicationExecutionState.terminated) {
                // TODO: This application has been newly launched. Initialize
                // your application here.
            } else {
                // TODO: This application has been reactivated from suspension.
                // Restore application state here.
            }
            args.setPromise(WinJS.UI.processAll());

            var appCache = new AppCache("workers.txt");

            
            var calculate = new PrimeNumbersCalculator();

            var btnCalculatePrimeNumberTo = document.getElementById("btnCalculatePrimeNumberTo");
            btnCalculatePrimeNumberTo.addEventListener("click", function (e) {
                var txtToNumber = document.getElementById("txtToNumber");
                var pnlResult = document.getElementById("result-calculatePrimeNumberTo");
                var workerData = new WorkerData(txtToNumber.value);
                var result = appCache.get("calculatePrimeNumberTo", workerData);
                if (result === undefined) {
                    calculate.calculatePrimeNumberTo(txtToNumber.value).then(function (response) {
                        workerData.result = response;
                        appCache.pushSafe("calculatePrimeNumberTo", workerData);
                        pnlResult.innerHTML = response;
                    }, function(error) {
                        pnlResult.innerHTML = error;
                    });
                } else {
                    pnlResult.innerHTML = result.result;
                }
            });
            
            var btnCalculateFirstNumbers = document.getElementById("btnCalculateFirstNumbers");
            btnCalculateFirstNumbers.addEventListener("click", function (e) {
                var txtToNumber = document.getElementById("txtNumber");
                var txtStopNumber = document.getElementById("txtStopNumber");
                var pnlResult = document.getElementById("result-calculateFirstNumbers");
                var workerData = new WorkerData(txtToNumber.value, txtStopNumber.value);
                var result = appCache.get("calculateFirstNumbers", workerData);
                if (result === undefined) {
                    calculate.calculateFirstNumbers(txtToNumber.value, txtStopNumber.value).then(function (response) {
                        workerData.result = response;
                        appCache.pushSafe("calculateFirstNumbers", workerData);
                        pnlResult.innerHTML = response;
                    }, function (error) {
                        pnlResult.innerHTML = error;
                    });
                } else {
                    pnlResult.innerHTML = result.result;
                }
            });
            
            var btnCalculateFromRange = document.getElementById("btnCalculateFromRange");
            btnCalculateFromRange.addEventListener("click", function (e) {
                var txtStartNumber = document.getElementById("txtStartNumber");
                var txtEndNumber = document.getElementById("txtEndNumber");
                var pnlResult = document.getElementById("result-calculateFromRange");
                var workerData = new WorkerData(txtStartNumber.value, txtEndNumber.value);
                var result = appCache.get("calculateFromRange", workerData);
                if (result === undefined) {
                    calculate.calculateFromRange(txtStartNumber.value, txtEndNumber.value).then(function(response) {
                        workerData.result = response;
                        appCache.pushSafe("calculateFromRange", workerData);
                        pnlResult.innerHTML = response;
                    }, function(error) {
                        pnlResult.innerHTML = error;
                    });
                } else {
                    pnlResult.innerHTML = result.result;
                }
            });
        }
    };

    app.oncheckpoint = function (args) {
        // TODO: This application is about to be suspended. Save any state
        // that needs to persist across suspensions here. You might use the
        // WinJS.Application.sessionState object, which is automatically
        // saved and restored across suspension. If you need to complete an
        // asynchronous operation before your application is suspended, call
        // args.setPromise().
    };

    app.start();
})();
