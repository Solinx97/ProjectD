document.addEventListener("click", (event) => {
    let dataContentAttribute = event.target.getAttribute("data-content");
    let dataValueAttribute = event.target.getAttribute("data-value");
    let dataBidsAttribute = event.target.getAttribute("data-bids");

    switch (dataContentAttribute) {
        case "bid-information":
            let bidInformationItem = document.querySelectorAll(`.bid-information-${+dataBidsAttribute}`)[+dataValueAttribute];

            if (bidInformationItem.getAttribute("hidden") != undefined)
                bidInformationItem.removeAttribute("hidden");
            else
                bidInformationItem.setAttribute("hidden", true);
            break;
        default:
            break;
    }
});

function ajaxQuery(ajaxType, ajaxUrl, loadElement, dataDictionary, resultId) {
    $.ajax({
        type: ajaxType,
        url: ajaxUrl,
        beforeSend: () => {
            $(loadElement).show();
        },
        complete: () => {
            $(loadElement).hide();
        },
        onBegin: "ajaxBegin",
        data: dataDictionary,
        success: (data) => {
            $(resultId).html(data);
        }
    });
}

function targetClear() {
    let allGroups = document.querySelectorAll(".group");
    for (var i = 0; i < allGroups.length; i++) {
        allGroups[i].classList.remove("target");
    }
}

function showFaculties() {
    let selFaculty = document.querySelector("#facultiesId");
    if (selFaculty != undefined) {
        ajaxQuery("GET", "/Directory/GetGroups", undefined, { "facultyId": +selFaculty.value }, "#result-1");
        selFaculty.onchange = function () {
            ajaxQuery("GET", "/Directory/GetGroups", undefined, { "facultyId": +selFaculty.value }, "#result-1");
        };
    }
}

showFaculties();

function showBids() {
    let setTeacher = document.querySelector("#teachersId");

    if (setTeacher != undefined) {
        ajaxQuery("GET", "/IndividualPlanTerm/GetBids", undefined, { "index": 0 }, "#result-2");
        setTeacher.onchange = function () {
            ajaxQuery("GET", "/IndividualPlanTerm/GetBids", undefined, { "index": setTeacher.selectedIndex }, "#result-2");
        };
    }
}

showBids();

function showPlanTimes() {
    let monthName = "";
    let planTimeTypeName = "";
    let subjectName = "";
    let selMonths = document.querySelector("#monthsId");

    if (selMonths != undefined) {
        let selPlanTimeTypes = document.querySelector("#planTimeTypesId");
        let selSubjects = document.querySelector("#subjectsId");

        monthName = selMonths[0].text;
        planTimeTypeName = selPlanTimeTypes[0].text;
        subjectName = selSubjects[0].text;

        ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimes", undefined,
            { "monthName": monthName, "planTimeTypeName": planTimeTypeName, "subjectName": subjectName }, "#result-3");

        ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimeType", undefined,
            { "planTimeTypeName": planTimeTypeName }, "#result-5");

        ajaxQuery("GET", "/IndividualPlanYear/GetGroups", undefined,
            { "subjectName": subjectName }, "#result-4");

        selMonths.onchange = function () {
            monthName = selMonths[selMonths.selectedIndex].text;
            ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimes", undefined,
                { "monthName": monthName, "planTimeTypeName": planTimeTypeName, "subjectName": subjectName  }, "#result-3");
        };

        selPlanTimeTypes.onchange = function () {
            planTimeTypeName = selPlanTimeTypes[selPlanTimeTypes.selectedIndex].text;
            ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimes", undefined,
                { "monthName": monthName, "planTimeTypeName": planTimeTypeName, "subjectName": subjectName }, "#result-3");
            ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimeType", undefined,
                { "planTimeTypeName": planTimeTypeName }, "#result-5");
        };

        selSubjects.onchange = function () {
            subjectName = selSubjects[selSubjects.selectedIndex].text;
            ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimes", undefined,
                { "monthName": monthName, "planTimeTypeName": planTimeTypeName, "subjectName": subjectName }, "#result-3");
            ajaxQuery("GET", "/IndividualPlanYear/GetGroups", undefined,
                { "subjectName": subjectName }, "#result-4");
        };
    }
}

showPlanTimes();

//function showGroups() {
//    let subjectName = "";
//    let selSubjects = document.querySelector("#subjectsId");

//    if (selSubjects != undefined) {
//        subjectName = selSubjects[0].text;

//        ajaxQuery("GET", "/IndividualPlanYear/GetGroups", undefined,
//            { "subjectName": subjectName }, "#result-4");
//        selSubjects.onchange = function () {
//            subjectName = selSubjects[selSubjects.selectedIndex].text;
//            ajaxQuery("GET", "/IndividualPlanYear/GetGroups", undefined,
//                { "subjectName": subjectName }, "#result-4");
//        };
//    }
//}

//showGroups();

//function showPlanTimeType() {
//    let planTimeTypeName = "";
//    let selPlanTimeTypeТуче = document.querySelector("#planTimeTypesId");

//    if (selPlanTimeTypeТуче != undefined) {
//        planTimeTypeName = selPlanTimeTypeТуче[0].text;

//        ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimeType", undefined,
//            { "planTimeTypeName": planTimeTypeName }, "#result-5");
//        selPlanTimeTypeТуче.onchange = function () {
//            planTimeTypeName = selPlanTimeTypeТуче[selPlanTimeTypeТуче.selectedIndex].text;
//            ajaxQuery("GET", "/IndividualPlanYear/GetPlanTimeType", undefined,
//                { "planTimeTypeName": planTimeTypeName }, "#result-5");
//        };
//    }
//}

//showPlanTimeType();