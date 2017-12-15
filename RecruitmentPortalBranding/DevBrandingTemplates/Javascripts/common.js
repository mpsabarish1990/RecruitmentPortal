/* Common method started  */
function GetConfigurationitem(page_title,page_key)
{
  var returnvalue = "";
   var requestUri = _spPageContextInfo.webAbsoluteUrl + "/_api/web/lists/getByTitle('System%20Configuration')/items?$filter=Title eq '"+page_title+"' and Key eq '"+page_key+"'";
        $.ajax(
            {
                url: requestUri,
                async: false,
                type: "GET",
                headers: { "Accept": "application/json; odata=verbose" },
                success: function (data) {
                    if (data.d.results) {
                        returnvalue = data.d.results[0].Value;
                    }
                  },
                  error: function (err) {
                    alert("error");
                    console.log("Configuration Item Error Message: " + JSON.stringify(err));
                }
            });
            return returnvalue;
}

/* Common method ended  */