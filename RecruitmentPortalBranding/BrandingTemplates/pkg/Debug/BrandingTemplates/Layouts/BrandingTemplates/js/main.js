$(document).ready(function(){
	$('#Datetimepicker1').datepicker({format: 'mm-dd-yyyy', autoclose: true});
	$('#Datetimepicker2').datepicker({ format: 'mm-dd-yyyy', autoclose: true });
	$('#Datetimepicker3').datepicker({ format: 'mm-dd-yyyy', autoclose: true});
	$('#Datetimepicker4').datepicker({ format: 'mm-dd-yyyy', autoclose: true });
	
	$(".dleterec").click(function(){
		alert('Are you sure want to delte this record?');
		$(this).parents("tr").remove();
	});
	$('.table-responsive').addClass('mtop-0');
	$('.table-responsive').removeClass('mtop-30');
         
	$( window ).scroll(function() {
		var pos = $('body').scrollTop();
		/*$('header').addClass('scroll');	
		$('.menu').addClass('afterscroll');*/
		if(pos < 75)
		{	
			/*$('header').removeClass('scroll');	
			$('.menu').removeClass('afterscroll');*/
			$('footer').removeClass('footerscrolled');
		}
		else { 
			$('footer').addClass('footerscrolled');
		}
	});




$( function() {
    // run the currently selected effect
    function runEffect() {
    	// get effect type from
      var selectedEffect = "blind";
      // Most effect types need no options passed by default
      var options = {};
      // some effects have required parameters
      if ( selectedEffect === "scale" ) {
        options = { percent: 100 };
      } else if ( selectedEffect === "size" ) {
        options = { to: { width: 100, height: 100 } };
      }
 
      // Run the effect
      $( ".toggleclass" ).toggle( selectedEffect, options, 500 );
    };
 
    // Set effect from select menu value
    $( ".toggleclick" ).on( "click", function() {
      runEffect();
      	var getDisval = $('.addrow.toggleclick').prop('disabled');
	 	if (getDisval == false)
      {
  		$('.addrow.toggleclick').prop('disabled', true);	
  		$('.editrec').prop('disabled', true);
  		$('.table-responsive').addClass('mtop-30');
      }
      else{
      	$('.addrow.toggleclick').prop('disabled', false);
      	$('.editrec').prop('disabled', false);
      	$('.table-responsive').removeClass('mtop-30');
      }

    });

	/*Radio Button Style Starts Here*/
 	$('.radiobg input').click(function() {
 		//debugger;
		if( $('.radiobg input').is(':checked'))		{ 
			//$(event.target).parents().eq(3);
			$(event.target).parents().eq(3).find('input[type="radio"]').parent().removeClass('checked');
			$(this).parent().addClass('checked');
		} 
	});
 	/*Radio Button Style Ends Here*/


  });

/*Menu Starts*/
$( function() {
    // run the currently selected effect
    function runEffect1() {
    	// get effect type from
      var selectedEffect1 = "blind";
      // Most effect types need no options passed by default
      var options1 = {};
      // some effects have required parameters
      if ( selectedEffect1 === "scale" ) {
        options1 = { percent: 100 };
      } else if ( selectedEffect1 === "size" ) {
        options1 = { to: { width: 100, height: 100 } };
      }
 
      // Run the effect
      $( ".resposnivemenu" ).toggle( selectedEffect1, options1, 500 );
    };


	 $( ".leftmenuclick" ).click(function() {
	 	$('.rightmenu').slideUp();
		runEffect1();

	});

});
/*Menu Ends*/


/*Menu Starts*/
$( function() {
    // run the currently selected effect
    function runEffect2() {
    	// get effect type from
      var selectedEffect2 = "blind";
      // Most effect types need no options passed by default
      var options2 = {};
      // some effects have required parameters
      if ( selectedEffect2 === "scale" ) {
        options2 = { percent: 100 };
      } else if ( selectedEffect2 === "size" ) {
        options2 = { to: { width: 100, height: 100 } };
      }
 
      // Run the effect
      $( ".rightmenu" ).toggle( selectedEffect2, options2, 500 );
    };


	 $( ".rightmenuclick" ).click(function() {
	 	$('.resposnivemenu').slideUp();
		runEffect2();

	});

});
/*Menu Ends*/


/*Menu Starts*/
$( function() {
    // run the currently selected effect
    function runEffect3() {
	   // get effect type from
      var selectedEffect3 = "blind";
      // Most effect types need no options passed by default
      var options3 = {};
      // some effects have required parameters
      if ( selectedEffect3 === "scale" ) {
        options3 = { percent: 100 };
      } else if ( selectedEffect3 === "size" ) {
        options3 = { to: { width: 100, height: 100 } };
      }
 
      // Run the effect
      	$( ".innermenu" ).toggle( selectedEffect3, options3, 500 );
   	  };


	 $( ".menu_hr" ).click(function() {
	 	runEffect3();
	});

});
/*Menu Ends*/





});

/*$(document).on('mouseup', function (e) {
	if (!$(e.target).closest('header').length) {
		$('.rightmenu').slideUp();
		$('.resposnivemenu').slideUp();
	}
});*/