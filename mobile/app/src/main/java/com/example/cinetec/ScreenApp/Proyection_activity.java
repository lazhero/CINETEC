package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.ContextThemeWrapper;
import android.widget.LinearLayout;

import com.example.cinetec.R;
import com.google.android.material.button.MaterialButton;

public class Proyection_activity extends AppCompatActivity {
    LinearLayout linear;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.proyection_activity);
        linear=(LinearLayout) findViewById(R.id.projection_linear_layout);
        just_prove();


    }
    public void just_prove() {
        for(int i=0;i<8;i++){
            add_projection("16:00 S6");
        }
    }

    public void add_projection(String text){
        int buttonStyle = R.style.projection_button_style;
        MaterialButton button = new MaterialButton(new ContextThemeWrapper(this, buttonStyle), null, buttonStyle);
        button.setText(text);
        linear.addView(button);
    }
}