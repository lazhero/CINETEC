package com.example.cinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.cinetec.ScreenApp.Cinema_select;
import com.example.cinetec.ScreenApp.Movie_selection;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
       switchActivities();
    }
    private void switchActivities() {
        Intent switchActivityIntent = new Intent(this, Movie_selection.class);
        startActivity(switchActivityIntent);
    }
}