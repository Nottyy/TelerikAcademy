package com.example.imageviewswithpopups;

import android.app.ActionBar.LayoutParams;
import android.app.Activity;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.util.TypedValue;
import android.view.Gravity;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.ImageButton;
import android.widget.LinearLayout;
import android.widget.PopupWindow;
import android.widget.TextView;

public class MainActivity extends Activity implements OnClickListener {

	ImageButton btnBird;
	ImageButton btnRabbit;
	ImageButton btnLauncher;
	Button btnDismiss;

	LinearLayout popupLayout;
	PopupWindow popupMessage;

	TextView animalDescription;
	Button getInfo;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		init();
		popupInit();
	}

	public void init() {
		btnBird = (ImageButton) this.findViewById(R.id.bird);
		btnRabbit = (ImageButton) this.findViewById(R.id.rabbit);
		btnLauncher = (ImageButton) this.findViewById(R.id.iclauncher);
		btnDismiss = new Button(this);
		btnDismiss.setText("Cancel");

		animalDescription = new TextView(this);
		getInfo = new Button(this);

		animalDescription.setId(100);
		animalDescription.setLayoutParams(new LayoutParams(
				LayoutParams.MATCH_PARENT, LayoutParams.WRAP_CONTENT));
		animalDescription.setGravity(Gravity.CENTER);
		animalDescription.setTextSize(TypedValue.COMPLEX_UNIT_SP, 18);
		animalDescription.setPadding(0, 0, 0, 20);

		getInfo.setId(200);
		getInfo.setText("Get additional information about me!");
		getInfo.setPadding(0, 0, 0, 20);

		popupLayout = new LinearLayout(this);
		popupLayout.setOrientation(1);
		popupLayout.addView(animalDescription);
		popupLayout.addView(getInfo);
		popupLayout.addView(btnDismiss);
	}

	public void popupInit() {
		btnBird.setOnClickListener(this);
		btnRabbit.setOnClickListener(this);
		btnLauncher.setOnClickListener(this);
		getInfo.setOnClickListener(this);
		btnDismiss.setOnClickListener(this);

		popupMessage = new PopupWindow(popupLayout, LayoutParams.MATCH_PARENT,
				LayoutParams.WRAP_CONTENT);
		popupMessage.setContentView(popupLayout);
	}

	@Override
	public void onClick(View v) {
		int viewId = v.getId();

		TextView currentTW = ((TextView) popupMessage.getContentView()
				.findViewById(100));

		if (viewId == R.id.bird) {
			currentTW.setText("I am a bird.");
			currentTW.setTag("bird");
			popupMessage.showAsDropDown(btnBird, 0, 0);
		} else if (viewId == R.id.iclauncher) {
			currentTW.setText("I am a launcher.");
			currentTW.setTag("launcher");
			popupMessage.showAsDropDown(btnLauncher, 0, 0);
		} else if (viewId == R.id.rabbit) {
			currentTW.setText("I am a rabbit.");
			currentTW.setTag("rabbit");
			popupMessage.showAsDropDown(btnRabbit, 0, 0);
		} else if (viewId == 200) {
			GetAnimalInformationFromTheWeb(v);
		} else {
			popupMessage.dismiss();
		}
	}

	private void GetAnimalInformationFromTheWeb(View view) {
		String tag = (String) (popupMessage.getContentView().findViewById(100))
				.getTag();
		String url;
		
		if (tag == "bird") {
			url = "http://en.wikipedia.org/wiki/Bird";
		} else if (tag == "rabbit") {
			url = "http://en.wikipedia.org/wiki/Rabbit";
		} else {
			url = "http://www.easyicon.net/language.en/569480-ic_launcher_android_icon.html";
		}

		Intent intent = new Intent(Intent.ACTION_VIEW);
		intent.setData(Uri.parse(url));
		startActivity(intent);
	}
}
