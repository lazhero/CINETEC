package com.example.cinetec;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.ScreenApp.Cinema_select;
import com.example.cinetec.ScreenApp.Login_Activity;
import com.example.cinetec.ScreenApp.Movie_selection;
import com.example.cinetec.ScreenApp.Proyection_activity;
import com.example.cinetec.ScreenApp.Seat_activity;

public class MainActivity extends AppCompatActivity {
    Db_helper DB;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        DB=new Db_helper(this);
        DB.SyncProcess();
       switchActivities();
    }
    private void switchActivities() {
        Intent switchActivityIntent = new Intent(this, Login_Activity.class);
        startActivity(switchActivityIntent);
    }
}