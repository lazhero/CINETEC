package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.R;
import com.example.cinetec.customviews.CinemaSelection;

public class Cinema_select extends AppCompatActivity {
    private LayoutInflater inflater;
    private LinearLayout BranchesList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cinema_select);
        inflater=(LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        BranchesList=this.findViewById(R.id.cinema_linear_layout);

    }

    public void add_branch(String text){
        CinemaSelection cinema=new CinemaSelection(this);
        cinema.set_text(text);
        BranchesList.addView(cinema);


    }
    public void click(View v){
        add_branch("Heredia");
    }
}