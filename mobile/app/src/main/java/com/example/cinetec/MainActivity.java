package com.example.cinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.cinetec.ScreenApp.Cinema_select;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        switchActivities();
    }
    private void switchActivities() {
        Intent switchActivityIntent = new Intent(this, Cinema_select.class);
        startActivity(switchActivityIntent);
    }
}