package com.example.cinetec.ScreenApp;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.content.res.Resources;
import android.os.Bundle;
import android.os.Handler;
import android.util.Log;
import android.util.TypedValue;
import android.view.View;
import android.widget.LinearLayout;

import com.example.cinetec.DB.Db_helper;
import com.example.cinetec.R;
import com.example.cinetec.customviews.Matrix_layout;
import com.example.cinetec.customviews.MovieView;
import com.example.cinetec.entities.Movie;
import com.example.cinetec.state.State;

import java.util.ArrayList;
import java.util.Timer;
import java.util.TimerTask;

public class Movie_selection extends AppCompatActivity {

    private int width;
    private int horizontal_margin;
    Matrix_layout layout;
    private Timer timer;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_movie_selection);
        layout=(Matrix_layout) findViewById(R.id.movies_matrix_layout);

        layout.post(new Runnable()
        {

            @Override
            public void run()
            {
                width=layout.getWidth();
                horizontal_margin=(int)(0.025*width);
                width=(width/2)-2*horizontal_margin;

                add_movies_example();

            }
        });





    }

    @Override
    protected void onStart() {
        super.onStart();
        width=layout.getMeasuredWidth();

    }

    @Override
    protected void onResume() {
        super.onResume();
        final Handler handler = new Handler();
        this.timer = new Timer();
        TimerTask doTask = new TimerTask() {
            @Override
            public void run() {
                handler.post(new Runnable() {
                    @SuppressWarnings("unchecked")
                    public void run() {
                        try {
                            Intent intent = getIntent();
                            finish();
                            startActivity(intent);
                        }
                        catch (Exception e) {
                            // TODO Auto-generated catch block
                        }
                    }
                });
            }
        };
        timer.schedule(doTask, 60000);

    }

    public void add_movies_example(){
        LinearLayout.LayoutParams params = new LinearLayout.LayoutParams(
                LinearLayout.LayoutParams.WRAP_CONTENT,
                LinearLayout.LayoutParams.WRAP_CONTENT
        );
        params.setMargins(horizontal_margin, 0, horizontal_margin, dp_px(2));
        Db_helper DB=new Db_helper(this);
        ArrayList<Movie> movies=DB.getMovies();
        if(movies==null)return;
        for(int i=0,size=movies.size();i<size;i++){
            MovieView movie=new MovieView(this);
            movie.set_cover_size(width);
            movie.setLayoutParams(params);
            movie.setMovie(movies.get(i));
            final int index=i;
            movie.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    State state=State.getInstance();
                    state.setMovie_original_name(movies.get(index).getOriginal_name());
                    go_to_projections();

                }
            });
            layout.add_view(movie);
        }

    }

    private int dp_px(int measure){
        Resources r = this.getResources();
        int px = (int) TypedValue.applyDimension(
                TypedValue.COMPLEX_UNIT_DIP,
                measure,
                r.getDisplayMetrics()
        );
        return px;
    }
    public void go_to_projections(){
        timer.cancel();
        timer.purge();
        Intent switchActivityIntent = new Intent(this, Proyection_activity.class);
        startActivity(switchActivityIntent);
    }

    @Override
    public void onBackPressed() {
        timer.cancel();
        timer.purge();
        super.onBackPressed();
    }
}