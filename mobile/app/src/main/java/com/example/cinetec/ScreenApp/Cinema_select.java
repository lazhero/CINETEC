package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.customviews.CinemaSelection;
import com.example.cinetec.entities.Cinema;
import com.example.cinetec.state.State;

import java.util.ArrayList;

public class Cinema_select extends AppCompatActivity {
    private LayoutInflater inflater;
    private LinearLayout BranchesList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cinema_select);
        inflater=(LayoutInflater) this.getSystemService(Context.LAYOUT_INFLATER_SERVICE);
        BranchesList=this.findViewById(R.id.cinema_linear_layout);
        getCinema();

    }


    public void add_branch(String text){
        CinemaSelection cinema=new CinemaSelection(this);
        cinema.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                State current_state=State.getInstance();
                current_state.setCinema_name(text);
                go_to_movies();

            }
        });
        cinema.set_text(text);
        BranchesList.addView(cinema);


    }
    public void getCinema(){
        Db_helper helper=new Db_helper(this);
        ArrayList<Cinema> cinemas=helper.getCinemas();
        Log.d("LARgo",Integer.toString(cinemas.size()));
        for(int i=0;i<cinemas.size();i++){
            add_branch(cinemas.get(i).getCinema_name());
        }

    }
    public void go_to_movies(){
        Intent switchActivityIntent = new Intent(this, Movie_selection.class);
        startActivity(switchActivityIntent);
    }

}